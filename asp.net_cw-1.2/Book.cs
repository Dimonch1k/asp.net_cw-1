using System.ComponentModel.DataAnnotations;

namespace asp.net_cw_1._2
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(0, 1000)]
        public int Price { get; set; }
    }
}
