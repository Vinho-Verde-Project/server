using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class TaskType:ObjectGraphType<Task>
   {
      public TaskType()
      {
         Field(_ => _.Id);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.Status);
      }
   }

   public class InputTaskType: InputObjectGraphType<Task>
   {
      public InputTaskType()
      {
         Name = "InputTaskType";
         Field(_ => _.Id);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.Status);
      }
   }
}