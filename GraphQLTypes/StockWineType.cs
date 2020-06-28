using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StockWineType:ObjectGraphType<StockWine>
   {
      public StockWineType(IWineData _wineData,
                           IStockData _stockData,
                           IEmployeeData _employeeData)
      {
         Field(_ => _.StockId);
         Field(_ => _.WineId);
         Field(_ => _.Quantity);
         Field(_ => _.EmployeeId);
         Field(_ => _.EntryDate);
         Field(_ => _.Unit);
         Field<WineType>(
            "wine",
            resolve: context => _wineData.GetAsync(context.Source.WineId)
         );
         Field<StockType>(
            "stock",
            resolve: context => _stockData.GetAsync(context.Source.StockId)
         );
         Field<EmployeeType>(
            "employee",
            resolve: context => _employeeData.GetAsync(context.Source.EmployeeId)
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
         Field(_ => _.Quantity);
         Field(_ => _.EmployeeId);
         Field(_ => _.EntryDate);
         Field(_ => _.Unit);
      }
   }
}