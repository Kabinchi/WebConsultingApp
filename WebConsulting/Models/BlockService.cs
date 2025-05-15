using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebConsulting.Models
{
    public class BlockService
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ServiceBlock))]
        public int BlockId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        // Новое поле: краткое описание услуги
        public string Description { get; set; }

        // Три текстовые секции модального окна
        public string Section1 { get; set; }
        public string Section2 { get; set; }
        public string Section3 { get; set; }

        // Новое поле: результаты услуги
        public string Results { get; set; }

        public virtual ServiceBlock ServiceBlock { get; set; }
    }
}
