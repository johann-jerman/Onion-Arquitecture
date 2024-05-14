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
    public class OrderProducts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

    }
}
