namespace ReverseImageSearch.Server.Models
{
    public class ImageMetadata
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        private DateTime _uploadDate;
        public DateTime UploadDate
        {
            get => _uploadDate;
            set => _uploadDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
    }
}
