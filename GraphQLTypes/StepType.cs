using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StepType:ObjectGraphType<Step>
   {
      public StepType(IEmployeeData _employeeData,
                      ITaskData _taskData)
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Status);
         Field(_ => _.Quantity);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.EmployeeId);
         Field(_ => _.TaskId);
         Field<ProductType>("products");
         Field<EmployeeType>(
            "employee",
            resolve: context => _employeeData.GetAsync(context.Source.EmployeeId));
         Field<TaskType>(
            "task",
            resolve: context => _taskData.GetAsync(context.Source.TaskId));
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
         Field<ListGraphType<InputProductType>>("products");
      }
   }

}