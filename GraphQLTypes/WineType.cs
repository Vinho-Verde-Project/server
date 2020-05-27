using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class WineType:ObjectGraphType<Wine>
   {
      public WineType()
      {
         Field(_ => _.Id);
         Field(_ => _.Batch);
         Field(_ => _.ProductionDate);
         Field(_ => _.ShelfLife);
         Field(_ => _.CategoryId);
         Field(_ => _.TaskId);
      }
   }

   public class InputWineType:InputObjectGraphType<Wine>
   {
      public InputWineType()
      {
         Name = "InputWineType";
         Field(_ => _.Id);
         Field(_ => _.Batch);
         Field(_ => _.ProductionDate);
         Field(_ => _.ShelfLife);
         Field(_ => _.CategoryId);
         Field(_ => _.TaskId);
      }
   }

}