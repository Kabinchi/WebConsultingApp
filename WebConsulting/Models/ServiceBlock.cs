using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebConsulting.Models
{
    public class ServiceBlock
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        public virtual ICollection<BlockService> BlockServices { get; set; }
            = new List<BlockService>();
    }
}
