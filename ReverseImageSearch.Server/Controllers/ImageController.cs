using Microsoft.AspNetCore.Mvc;
using ReverseImageSearch.Server.Data;
using ReverseImageSearch.Server.Models;

namespace ReverseImageSearch.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly string _imageStoragePath;

        public ImageController()
        {
            _imageStoragePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images");
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromServices] AppDbContext dbContext)
        {
            if (file == null)
            {
                return BadRequest("No file uploaded or file is empty");
            }

            try
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var filePath = Path.Combine(_imageStoragePath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var metadata = new ImageMetadata
                {
                    FileName = file.FileName,
                    FilePath = $"uploads/{uniqueFileName}",
                    UploadDate = DateTime.UtcNow
                };

                dbContext.ImageMetadata.Add(metadata);
                await dbContext.SaveChangesAsync();

                return Ok(new { metadata.Id, metadata.FileName, metadata.FilePath, metadata.UploadDate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
