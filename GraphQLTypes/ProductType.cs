using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class ProductType:ObjectGraphType<Product>
   {
      public ProductType(IStockProductData _stockProductData,
                         ICategoryData _categoryData,
                         IStepData _stepData)
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.CategoryId);
         Field(_ => _.Type);
         Field<ListGraphType<StockProductType>>(
            "stockProduct",
            resolve: context => _stockProductData.GetStocksAsync(context.Source.Id));
         Field<CategoryType>(
            "category",
            resolve: context => _categoryData.GetAsync(context.Source.CategoryId));

      }
   }

      public class InputProductType:InputObjectGraphType<Product>
   {
      public InputProductType()
      {
         Name = "InputProductType";
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.CategoryId);
         Field(_ => _.Type);
      }
   }
}
