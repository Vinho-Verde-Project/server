using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class StepType:ObjectGraphType<Step>
   {
      public StepType()
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Status);
         Field(_ => _.Quantity);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.EmployeeId);
         Field(_ => _.TaskId);
      }
   }

   public class InputStepType:InputObjectGraphType<Step>
   {
      public InputStepType()
      {
         Name = "InputStepType";
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Status);
         Field(_ => _.Quantity);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.EmployeeId);
         Field(_ => _.TaskId);
      }
   }

}