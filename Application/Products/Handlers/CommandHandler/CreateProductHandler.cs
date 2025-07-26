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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Domain.Entities.Product
            {
                Name = request.Name,
                ProduceDate = request.ProduceDate,
                ManufacturePhone = request.ManufacturePhone,
                ManufactureEmail = request.ManufactureEmail,
                IsAvailable = request.IsAvailable
            };

            await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
