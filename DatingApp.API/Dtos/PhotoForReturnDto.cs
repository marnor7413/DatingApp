using System;

namespace DatingApp.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateADded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}