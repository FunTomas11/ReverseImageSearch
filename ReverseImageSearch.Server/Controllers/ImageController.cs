using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> UploadImage(IFormFile file)
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

                return Ok(new { FileName = uniqueFileName, FilePath = $"uploads/images/{uniqueFileName}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
