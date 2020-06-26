using Microsoft.EntityFrameworkCore;
using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StockProductType:ObjectGraphType<StockProduct>
   {
      public StockProductType(IProductData _productData,
                              IStockData _stockData)
      {
         Field(_ => _.StockId);
         Field(_ => _.ProductId);
         Field<ProductType>(
            "product",
            resolve: context => _productData.GetAsync(context.Source.ProductId)
         );
         Field<StockType>(
            "stock",
            resolve: context => _stockData.GetAsync(context.Source.StockId)
         );
         Field(_ => _.MinQantity);
      }
   }

   public class InputStockProductType:InputObjectGraphType<StockProduct>
   {
      public InputStockProductType()
      {
         Name = "InputStockProductType";
         Field(_ => _.StockId);
         Field(_ => _.ProductId);
         Field(_ => _.MinQantity);
      }
   }

}