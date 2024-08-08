using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Service.Dto.DTOs
{
    public class OrderCreateDto
    {
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime OrderCreatedDate { get; set; }
    }
}
