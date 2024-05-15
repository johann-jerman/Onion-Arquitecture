using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }


        // relation with category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //relation with order from pivot
        //[JsonIgnore]
        public virtual ICollection<Order> Order { get; set; } = new List<Order>();

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
