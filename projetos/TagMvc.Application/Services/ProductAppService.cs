using TagMvc.Application.Interfaces;
using TagMvc.Application.Products.Commands;
using TagMvc.Application.Products.Dtos;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;

namespace TagMvc.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductAppService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateProductAsync(CreateProductCommand command)
    {
        var product = new Product
        {
            Name = command.Name,
            Price = command.Price
        };

        await _productRepository.AddAsync(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        
        // Em um projeto real, use uma biblioteca como o AutoMapper para isso.
        return products.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price });
    }
}