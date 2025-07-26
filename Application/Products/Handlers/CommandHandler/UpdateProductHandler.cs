using Application.Products.Commands;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers.CommandHandler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            product.Name = request.Name;
            product.ProduceDate = request.ProduceDate;
            product.ManufacturePhone = request.ManufacturePhone;
            product.ManufactureEmail = request.ManufactureEmail;
            product.IsAvailable = request.IsAvailable;

            await _repository.UpdateAsync(product);

            
        }
    }
}
