using Mapster;
using MiniDbApp.Database.Database.Tables;
using MiniDbApp.Models.Order;
using Product = MiniDbApp.Models.Product.Product;

namespace MiniDbApp.Database.Adapters;

public static class ProductInOrderAdapter
{
    public static TypeAdapterConfig Config;

    static ProductInOrderAdapter()
    {
        Config = new TypeAdapterConfig().ForType<ProductInOrder, OrderProduct>()
            .Map(dest => dest.Product, src => src.Product.Adapt<Product>())
            .Map(dest => dest.Quantity, src => src.Quantity).Config;
    }
}