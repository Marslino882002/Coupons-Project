namespace Services.DTOs
{
    public class RequestQrCodeGenerationDto
    {
        public string Payload { get; set; }
        public string EmployeeId { get; set; }
        public string Ar_FullName { get; set; }
        public int PixelsPerModule { get; set; }

    }
}