using Application.Exceptions;
using Application.Products.Commands;
using Application.Repositories;
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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public UpdateProductHandler(IProductRepository repository , IHttpContextAccessor httpContext)
        {
            _repository = repository;
            _httpContextAccessor = httpContext;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ProductNotFoundException(request.Id);


            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (product.CreatedByUserId != userId)
                throw new UnauthorizedProductAccessException();


            product.Name = request.Name;
            product.ProduceDate = request.ProduceDate;
            product.ManufacturePhone = request.ManufacturePhone;
            product.ManufactureEmail = request.ManufactureEmail;
            product.IsAvailable = request.IsAvailable;

            await _repository.UpdateAsync(product);

            
        }
    }
}
