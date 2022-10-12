namespace WebSop.gRPC.Services
{
    public class ProductGrpcService : Product.
    {
        //private readonly IProductService _productService;

        //public ProductGrpcService(IProductService productService)
        //{
        //    _productService = productService;
        //}

        //public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
        //{
        //    ProductList result = new ProductList();
        //    var products = await _productService.GetAll();

        //    result.Items.AddRange(products.Select(p => new ProductItem()
        //    {
        //        Name = p.Name,
        //        Id = p.Id.ToString(),
        //        Price = (double)p.Price,
        //        Quantity = p.Quantity
        //    }));

        //    return result;
        //}
    }
}