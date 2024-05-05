using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        //public int? Id { get; set; }
        //public string Name { get; set; }
        //public int Price{ get; set; }
        //public string? Description { get; set; }
        //public int CategoryId { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? UpdatedAt { get; set; }
        //public DateTime? DeletedAt { get; set; }
    }
}
