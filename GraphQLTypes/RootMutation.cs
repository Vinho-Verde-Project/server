using GraphQL.Types;
using Api.Models;
using Api.Data;

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
                           ICategoryData categoryData)
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
            arguments: new QueryArguments(
               new QueryArgument<InputEmployeeType>(){ Name = "employee"}
            ),
            resolve: context =>
            {
               var employee = context.GetArgument<Employee>("employee");
               return employeeData.Update(employee);
            }
         );

         Field<EmployeeType>(
            "deleteEmployee",
            arguments: new QueryArguments(
               new QueryArgument<InputEmployeeType>(){ Name = "employee"}
            ),
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
            arguments: new QueryArguments(
               new QueryArgument<InputRoleType>(){ Name = "role"}
            ),
            resolve: context =>
            {
               var role = context.GetArgument<Role>("role");
               return roleData.Update(role);
            }
         );

         Field<RoleType>(
            "deleteRole",
            arguments: new QueryArguments(
               new QueryArgument<InputRoleType>(){ Name = "role"}
            ),
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
            arguments: new QueryArguments(
               new QueryArgument<InputPermissionType>(){ Name = "permission"}
            ),
            resolve: context =>
            {
               var permission = context.GetArgument<Permission>("permission");
               return permissionData.Update(permission);
            }
         );

         Field<PermissionType>(
            "deletePermission",
            arguments: new QueryArguments(
               new QueryArgument<InputPermissionType>(){ Name = "permission"}
            ),
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
            arguments: new QueryArguments(
               new QueryArgument<InputTaskType>(){ Name = "task"}
            ),
            resolve: context =>
            {
               var task = context.GetArgument<Task>("task");
               return taskData.Update(task);
            }
         );

         Field<TaskType>(
            "deleteTask",
            arguments: new QueryArguments(
               new QueryArgument<InputTaskType>(){ Name = "task"}
            ),
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
            arguments: new QueryArguments(
               new QueryArgument<InputCategoryType>(){ Name = "category"}
            ),
            resolve: context =>
            {
               var category = context.GetArgument<Category>("category");
               return categoryData.Update(category);
            }
         );

         Field<CategoryType>(
            "deleteCategory",
            arguments: new QueryArguments(
               new QueryArgument<InputCategoryType>(){ Name = "category"}
            ),
            resolve: context =>
            {
               var category = context.GetArgument<Category>("category");
               categoryData.Delete(category);
               return category;
               
            }
         );


         
      }
   }


}