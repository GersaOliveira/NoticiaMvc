using TagMvc.Application.Products.Commands;
using TagMvc.Application.Products.Dtos;

namespace TagMvc.Application.Interfaces;

public interface IProductAppService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task CreateProductAsync(CreateProductCommand command);
}