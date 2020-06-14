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
         Field(_ => _.Type);
         Field(_ => _.StepId);

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
         Field(_ => _.StepId);
      }
   }
}
