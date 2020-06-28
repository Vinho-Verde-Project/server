using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StockType:ObjectGraphType<Stock>
   {
      public StockType( IStockProductData _stockProductData,
                        IStockWineData _stockWineData)
      {
         Field(_ => _.Id);
         Field(_ => _.Title);
         Field<ListGraphType<StockProductType>>(
            "stockProduct",
            resolve: context => _stockProductData.GetProductsAsync(context.Source.Id));
         Field<ListGraphType<StockWineType>>(
            "stockWine",
            resolve: context => _stockWineData.GetWinesAsync(context.Source.Id));
      }
   }

   public class InputStockType:InputObjectGraphType<Stock>
   {
      public InputStockType()
      {
         Name = "InputStockType";
         Field(_ => _.Id);
         Field(_ => _.Title);
      }
   }

}