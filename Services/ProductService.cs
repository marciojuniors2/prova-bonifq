using ProvaPub.Models;
using ProvaPub.Repository;

public class ProductService
{
    private readonly TestDbContext _ctx;

    public ProductService(TestDbContext ctx)
    {
        _ctx = ctx;
    }

    public ProductList ListProducts(int page)
    {
        var pageSize = 10;
        var startIndex = (page >= 1) ? (page - 1) * pageSize : 0;
        var totalCount = _ctx.Products.Count();

        var products = _ctx.Products
            .Skip(startIndex)
            .Take(pageSize)
            .ToList();

        return new ProductList()
        {
            HasNext = startIndex + pageSize < totalCount,
            TotalCount = totalCount,
            Products = products
        };
    }


}