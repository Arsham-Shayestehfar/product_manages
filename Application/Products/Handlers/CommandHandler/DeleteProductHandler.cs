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
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteProductHandler(IProductRepository repository , IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContext;
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _repository.GetByIdAsync(request.Id);
            if (product == null)
                throw new ProductNotFoundException(request.Id);

            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (product.CreatedByUserId != userId)
                throw new UnauthorizedProductAccessException();

            await _repository.DeleteAsync(product);
           
        }
    }
}
