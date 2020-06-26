using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StockWineType:ObjectGraphType<StockWine>
   {
      public StockWineType(IWineData _wineData,
                           IStockData _stockData)
      {
         Field(_ => _.StockId);
         Field(_ => _.WineId);
         Field<WineType>(
            "wine",
            resolve: context => _wineData.GetAsync(context.Source.WineId)
         );
         Field<StockType>(
            "stock",
            resolve: context => _stockData.GetAsync(context.Source.StockId)
         );
      }
   }

   public class InputStockWineType:InputObjectGraphType<StockWine>
   {
      public InputStockWineType()
      {
         Name = "InputStockWineType";
         Field(_ => _.StockId);
         Field(_ => _.WineId);
      }
   }

}