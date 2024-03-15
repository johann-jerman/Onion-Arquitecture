using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalAmount { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }

        public DateTime CreatedAt{ get; set; }

        public DateTime UpdatedAt { get; set;}

        public DateTime DeletedAt { get; set;}
    }
}