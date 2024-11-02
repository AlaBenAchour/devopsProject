using System.ComponentModel.DataAnnotations;

namespace DevopsApi.Models
{
    public class Book
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string mail { get; set; }

     
    }
}
