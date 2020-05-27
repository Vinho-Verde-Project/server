using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class CategoryType:ObjectGraphType<Category>
   {
      public CategoryType()
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Characteristics);

      }
   }

   public class InputCategoryType:InputObjectGraphType<Category>
   {
      public InputCategoryType()
      {
         Name = "InputCategoryType";
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Characteristics);
      }
   }
}