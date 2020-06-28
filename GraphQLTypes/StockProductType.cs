using Microsoft.EntityFrameworkCore;
using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StockProductType:ObjectGraphType<StockProduct>
   {
      public StockProductType(IProductData _productData,
                              IStockData _stockData,
                              IEmployeeData _employeeData)
      {
         Field(_ => _.StockId);
         Field(_ => _.ProductId);
         Field(_ => _.MinQantity);
         Field(_ => _.Quantity);
         Field(_ => _.EmployeeId);
         Field(_ => _.EntryDate);
         Field(_ => _.Unit);
         Field<ProductType>(
            "product",
            resolve: context => _productData.GetAsync(context.Source.ProductId)
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

   public class InputStockProductType:InputObjectGraphType<StockProduct>
   {
      public InputStockProductType()
      {
         Name = "InputStockProductType";
         Field(_ => _.StockId);
         Field(_ => _.ProductId);
         Field(_ => _.MinQantity);
         Field(_ => _.Quantity);
         Field(_ => _.EmployeeId);
         Field(_ => _.EntryDate);
         Field(_ => _.Unit);
      }
   }

}