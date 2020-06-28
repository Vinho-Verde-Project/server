using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class StepType:ObjectGraphType<Step>
   {
      public StepType(IEmployeeData _employeeData,
                      ITaskData _taskData,
                      IProductData _productData)
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.Status);
         Field(_ => _.Quantity);
         Field(_ => _.StartedAt);
         Field(_ => _.EndedAt);
         Field(_ => _.EmployeeId);
         Field(_ => _.TaskId);
         // Field(_ => _.ProductId);
         Field<EmployeeType>(
            "employee",
            resolve: context => _employeeData.GetAsync(context.Source.EmployeeId));
         Field<TaskType>(
            "task",
            resolve: context => _taskData.GetAsync(context.Source.TaskId));
         // Field<ProductType>(
         //    "product",
         //    resolve: context => _productData.GetAsync(context.Source.ProductId));
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
         // Field<Product>(_ => _.Products);
      }
   }

}