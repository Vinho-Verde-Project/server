using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class ProductType:ObjectGraphType<Product>
   {
      public ProductType()
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.CategoryId);
         Field(_ => _.Category);
         Field(_ => _.Type);
         Field(_ => _.StepId);
         Field(_ => _.Step);
         Field(_ => _.StockProducts);
         Field(_ => _.ProductCategories);

      }
   }

}