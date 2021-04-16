using System.ComponentModel.DataAnnotations;

namespace keeper_server.Models
{
    public class Keep
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Keeps { get; set; }
        public bool IsPrivate { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}