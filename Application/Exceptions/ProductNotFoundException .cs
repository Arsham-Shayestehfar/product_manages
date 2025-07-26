using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int productId)
            : base("محصول", productId)
        {
        }
    }
}
