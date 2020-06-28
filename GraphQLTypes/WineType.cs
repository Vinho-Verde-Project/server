using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class WineType:ObjectGraphType<Wine>
   {
      public WineType(IStockWineData _stockWineData,
                      ICategoryData _categoryData,
                      ITaskData _taskData)
      {
         Field(_ => _.Id);
         Field(_ => _.Batch);
         Field(_ => _.ProductionDate);
         Field(_ => _.ShelfLife);
         Field(_ => _.CategoryId);
         Field(_ => _.TaskId);
         Field<ListGraphType<StockWineType>>(
            "stockWine",
            resolve: context => _stockWineData.GetStocksAsync(context.Source.Id));
         Field<CategoryType>(
            "category",
            resolve: context => _categoryData.GetAsync(context.Source.CategoryId));
         Field<TaskType>(
            "task",
            resolve: context => _taskData.GetAsync(context.Source.TaskId));
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