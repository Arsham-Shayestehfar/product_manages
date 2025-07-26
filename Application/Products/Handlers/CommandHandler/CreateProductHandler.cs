using Application.Products.Commands;
using Application.Repositories;
using DotNetOpenAuth.InfoCard;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Handlers.CommandHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateProductHandler(IProductRepository repository, IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContextAccessor = httpContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var product = new Domain.Entities.Product
            {
                Name = request.Name,
                ProduceDate = request.ProduceDate,
                ManufacturePhone = request.ManufacturePhone,
                ManufactureEmail = request.ManufactureEmail,
                IsAvailable = request.IsAvailable,
                 CreatedByUserId = userId
            };

            await _repository.AddAsync(product);
            return product.Id;
        }
    }
}
