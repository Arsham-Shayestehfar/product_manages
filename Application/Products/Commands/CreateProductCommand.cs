using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public record CreateProductCommand(string Name, DateTime ProduceDate, string ManufacturePhone, string ManufactureEmail, bool IsAvailable)
    : IRequest<int>;
}
