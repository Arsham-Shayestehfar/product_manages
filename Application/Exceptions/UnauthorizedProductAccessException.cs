using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnauthorizedProductAccessException : Exception
    {
        public UnauthorizedProductAccessException()
            : base("شما اجازه دسترسی به این محصول را ندارید.")
        {
        }
    }
}
