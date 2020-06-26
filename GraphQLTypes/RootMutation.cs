using GraphQL.Types;
using Api.Models;
using Api.Data;
using System;

namespace Api.GraphQLTypes
{
   public class RootMutation:ObjectGraphType
   {
      // public RootMutation(IWineData wineData)
      // {
      //    Field<WineType>(
      //       "addWine",
      //       arguments: new QueryArguments
      //       {
      //          new QueryArgument<InputWineType>(){ Name = "wine"}
      //       },
      //       resolve: context =>
      //       {
      //          var wine = context.GetArgument<Wine>("wine");
      //          wineData.AddWine(wine);
      //          return null;
      //       }
      //    );
      // }

      public RootMutation( IEmployeeData employeeData,
                           IRoleData roleData,
                           IPermissionData permissionData,
                           ITaskData taskData,
                           ICategoryData categoryData,
                           IStockData stockData,
                           IStepData stepData,
                           IWineData wineData,
                           IProductData productData,
                           IStockProductData stockProductData,
                           IStockWineData stockWineData)
      {
// EMPLOYEE
         Field<EmployeeType>(
            "addEmployee",
            arguments: new QueryArguments
            {
               new QueryArgument<InputEmployeeType>(){ Name = "employee"}
            },
            resolve: context =>
            {
               var employee = context.GetArgument<Employee>("employee");
               return employeeData.AddEmployee(employee);
               
            }
         );

         Field<EmployeeType>(
            "updateEmployee",
            arguments: new QueryArguments{
               new QueryArgument<InputEmployeeType>(){ Name = "employee"}
            },
            resolve: context =>
            {
               var employee = context.GetArgument<Employee>("employee");
               return employeeData.Update(employee);
            }
         );

         Field<EmployeeType>(
            "deleteEmployee",
            arguments: new QueryArguments{
               new QueryArgument<InputEmployeeType>(){ Name = "employee"}
            },
            resolve: context =>
            {
               var employee = context.GetArgument<Employee>("employee");
               employeeData.Delete(employee);
               return employee;
               
            }
         );


// ROLE
         Field<RoleType>(
            "addRole",
            arguments: new QueryArguments
            {
               new QueryArgument<InputRoleType>(){ Name = "role"}
            },
            resolve: context =>
            {
               var role = context.GetArgument<Role>("role");
               return roleData.AddRole(role);
               
            }
         );

         Field<RoleType>(
            "updateRole",
            arguments: new QueryArguments{
               new QueryArgument<InputRoleType>(){ Name = "role"}
            },
            resolve: context =>
            {
               var role = context.GetArgument<Role>("role");
               return roleData.Update(role);
            }
         );

         Field<RoleType>(
            "deleteRole",
            arguments: new QueryArguments{
               new QueryArgument<InputRoleType>(){ Name = "role"}
            },
            resolve: context =>
            {
               var role = context.GetArgument<Role>("role");
               roleData.Delete(role);
               return role;
               
            }
         );

// PERMISSION
         Field<PermissionType>(
            "addPermission",
            arguments: new QueryArguments
            {
               new QueryArgument<InputPermissionType>(){ Name = "permission"}
            },
            resolve: context =>
            {
               var permission = context.GetArgument<Permission>("permission");
               return permissionData.AddPermission(permission);
               
            }
         );

         Field<PermissionType>(
            "updatePermission",
            arguments: new QueryArguments{
               new QueryArgument<InputPermissionType>(){ Name = "permission"}
            },
            resolve: context =>
            {
               var permission = context.GetArgument<Permission>("permission");
               return permissionData.Update(permission);
            }
         );

         Field<PermissionType>(
            "deletePermission",
            arguments: new QueryArguments{
               new QueryArgument<InputPermissionType>(){ Name = "permission"}
            },
            resolve: context =>
            {
               var permission = context.GetArgument<Permission>("permission");
               permissionData.Delete(permission);
               return permission;
               
            }
         );


// TASK
         Field<TaskType>(
            "addTask",
            arguments: new QueryArguments
            {
               new QueryArgument<InputTaskType>(){ Name = "task"}
            },
            resolve: context =>
            {
               var task = context.GetArgument<Task>("task");
               return taskData.AddTask(task);
            }
         );

         Field<TaskType>(
            "updateTask",
            arguments: new QueryArguments{
               new QueryArgument<InputTaskType>(){ Name = "task"}
            },
            resolve: context =>
            {
               var task = context.GetArgument<Task>("task");
               return taskData.Update(task);
            }
         );

         Field<TaskType>(
            "deleteTask",
            arguments: new QueryArguments{
               new QueryArgument<InputTaskType>(){ Name = "task"}
            },
            resolve: context =>
            {
               var task = context.GetArgument<Task>("task");
               taskData.Delete(task);
               return task;
               
            }
         );


// CATEGORY
         Field<CategoryType>(
            "addCategory",
            arguments: new QueryArguments
            {
               new QueryArgument<InputCategoryType>(){ Name = "category"}
            },
            resolve: context =>
            {
               var category = context.GetArgument<Category>("category");
               return categoryData.AddCategory(category);
               
            }
         );

         Field<CategoryType>(
            "updateCategory",
            arguments: new QueryArguments{
               new QueryArgument<InputCategoryType>(){ Name = "category"}
            },
            resolve: context =>
            {
               var category = context.GetArgument<Category>("category");
               return categoryData.Update(category);
            }
         );

         Field<CategoryType>(
            "deleteCategory",
            arguments: new QueryArguments{
               new QueryArgument<InputCategoryType>(){ Name = "category"}
            },
            resolve: context =>
            {
               var category = context.GetArgument<Category>("category");
               categoryData.Delete(category);
               return category;
               
            }
         );

// STOCK
         Field<StockType>(
            "addStock",
            arguments: new QueryArguments
            {
               new QueryArgument<InputStockType>(){ Name = "stock"}
            },
            resolve: context =>
            {
               var stock = context.GetArgument<Stock>("stock");
               return stockData.AddStock(stock);
               
            }
         );

         Field<StockType>(
            "updateStock",
            arguments: new QueryArguments{
               new QueryArgument<InputStockType>(){ Name = "stock"}
            },
            resolve: context =>
            {
               var stock = context.GetArgument<Stock>("stock");
               return stockData.Update(stock);
            }
         );

         Field<StockType>(
            "deleteStock",
            arguments: new QueryArguments{
               new QueryArgument<InputStockType>(){ Name = "stock"}
            },
            resolve: context =>
            {
               var stock = context.GetArgument<Stock>("stock");
               stockData.Delete(stock);
               return stock;
               
            }
         );

// STEP
         Field<StepType>(
            "addStep",
            arguments: new QueryArguments
            {
               new QueryArgument<InputStepType>(){ Name = "step"}
            },
            resolve: context =>
            {
               var step = context.GetArgument<Step>("step");
               return stepData.AddStep(step); 
               
            }
         );

         Field<StepType>(
            "updateStep",
            arguments: new QueryArguments{
               new QueryArgument<InputStepType>(){ Name = "step"}
            },
            resolve: context =>
            {
               var step = context.GetArgument<Step>("step");
               return stepData.Update(step);
            }
         );

         Field<StepType>(
            "deleteStep",
            arguments: new QueryArguments{
               new QueryArgument<InputStepType>(){ Name = "step"}
            },
            resolve: context =>
            {
               var step = context.GetArgument<Step>("step");
               stepData.Delete(step);
               return step;
               
            }
         );

// WINE

         Field<WineType>(
            "addWine",
            arguments: new QueryArguments
            {
               new QueryArgument<InputWineType>(){ Name = "wine"}
            },
            resolve: context =>
            {
               var wine = context.GetArgument<Wine>("wine");
               return wineData.AddWine(wine);
               
            }
         );

         Field<WineType>(
            "updateWine",
            arguments: new QueryArguments{
               new QueryArgument<InputWineType>(){ Name = "wine"}
            },
            resolve: context =>
            {
               var wine = context.GetArgument<Wine>("wine");
               return wineData.Update(wine);
            }
         );

         Field<WineType>(
            "deleteWine",
            arguments: new QueryArguments{
               new QueryArgument<InputWineType>(){ Name = "wine"}
            },
            resolve: context =>
            {
               var wine = context.GetArgument<Wine>("wine");
               wineData.Delete(wine);
               return wine;
               
            }
         );

// PRODUCT
         Field<ProductType>(
            "addProduct",
            arguments: new QueryArguments
            {
               new QueryArgument<InputProductType>(){ Name = "product"}
            },
            resolve: context =>
            {
               var product = context.GetArgument<Product>("product");
               return productData.AddProduct(product);
               
            }
         );

         Field<ProductType>(
            "updateProduct",
            arguments: new QueryArguments{
               new QueryArgument<InputProductType>(){ Name = "product"}
            },
            resolve: context =>
            {
               var product = context.GetArgument<Product>("product");
               return productData.Update(product);
            }
         );

         Field<ProductType>(
            "deleteProduct",
            arguments: new QueryArguments{
               new QueryArgument<InputProductType>(){ Name = "product"}
            },
            resolve: context =>
            {
               var product = context.GetArgument<Product>("product");
               productData.Delete(product);
               return product;
               
            }
         );

// StockProduct
         Field<StockProductType>(
            "addStockProduct",
            arguments: new QueryArguments
            {
               new QueryArgument<InputStockProductType>(){ Name = "stockProduct"}
            },
            resolve: context =>
            {
               var stockProduct = context.GetArgument<StockProduct>("stockProduct");
               return stockProductData.AddStockProduct(stockProduct);
               
            }
         );

         Field<StockProductType>(
            "updateStockProduct",
            arguments: new QueryArguments{
               new QueryArgument<InputStockProductType>(){ Name = "stockProduct"}
            },
            resolve: context =>
            {
               var stockProduct = context.GetArgument<StockProduct>("stockProduct");
               return stockProductData.Update(stockProduct);
            }
         );

         Field<StockProductType>(
            "deleteStockProduct",
            arguments: new QueryArguments{
               new QueryArgument<InputStockProductType>(){ Name = "stockProduct"}
            },
            resolve: context =>
            {
               var stockProduct = context.GetArgument<StockProduct>("stockProduct");
               stockProductData.Delete(stockProduct);
               return stockProduct;
               
            }
         );

// StockWine
         Field<StockWineType>(
            "addStockWine",
            arguments: new QueryArguments
            {
               new QueryArgument<InputStockWineType>(){ Name = "stockWine"}
            },
            resolve: context =>
            {
               var stockWine = context.GetArgument<StockWine>("stockWine");
               return stockWineData.AddStockWine(stockWine);
               
            }
         );

         Field<StockWineType>(
            "updateStockWine",
            arguments: new QueryArguments{
               new QueryArgument<InputStockWineType>(){ Name = "stockWine"}
            },
            resolve: context =>
            {
               var stockWine = context.GetArgument<StockWine>("stockWine");
               return stockWineData.Update(stockWine);
            }
         );

         Field<StockWineType>(
            "deleteStockWine",
            arguments: new QueryArguments{
               new QueryArgument<InputStockWineType>(){ Name = "stockWine"}
            },
            resolve: context =>
            {
               var stockWine = context.GetArgument<StockWine>("stockWine");
               stockWineData.Delete(stockWine);
               return stockWine;
               
            }
         );
      }
   }


}