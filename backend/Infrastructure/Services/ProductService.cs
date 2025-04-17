// using Application.DTOs;

// namespace Infrastructure.Services
// {
//     public class ProductService : IProductService
//     {
//         private readonly IProductRepository _productRepository;

//         public ProductService(IProductRepository productRepository)
//         {
//             _productRepository = productRepository;
//         }

//         public async Task<IEnumerable<ProductDto>> GetAll()
//         {
//             throw new NotImplementedException();
//         }

//         public async Task<PaginationDTO<ProductDto>> GetAllWithPagination(int pageNumber, int pageSize)
//         {
//             //Get peginated data
//            throw new NotImplementedException();
//         }

//         public async Task<ProductDto> GetSingle(int id)
//         {
//             throw new NotImplementedException();
//         }



//         public async Task<ProductDto> Create(ProductDto model)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task Update(ProductDto model)
//         {
//             throw new NotImplementedException();
//         }

//         public async Task Delete(int id)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }