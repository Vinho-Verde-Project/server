using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class StockType:ObjectGraphType<Stock>
   {
      public StockType()
      {
         Field(_ => _.Id);
         Field(_ => _.Quantity);
         Field(_ => _.Warehouse);
         Field(_ => _.EmployeeId);
         Field(_ => _.Employee);
         Field(_ => _.EntryDate);
         Field(_ => _.StockProducts);
         Field(_ => _.StockWines);
      }
   }

}