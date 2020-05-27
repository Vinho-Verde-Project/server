using GraphQL.Types;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class RootQuery : ObjectGraphType
   {

      // public RootQuery(IWineData _wineData)
      // {
      //    Field<ListGraphType<WineType>>("wines", resolve: context =>
      //    {
      //       return _wineData.GetAllAsync();
      //    });
      // }

      public RootQuery(IEmployeeData _employeeData,
                        IRoleData _roleData,
                        IPermissionData _permissionData,
                        ITaskData _taskData,
                        ICategoryData _categoryData)
      {

//EMPLOYEES
         Field<ListGraphType<EmployeeType>>("employees", resolve: context =>
         {
            return _employeeData.GetAllAsync();
         });

         Field<EmployeeType>("employee",
            arguments: new QueryArguments
            {
               new QueryArgument<IntGraphType> { Name = "id" }
            }, 
            resolve: context =>
            {
               int id = context.GetArgument<int>("id");
               return _employeeData.GetAsync(id);
            });

         Field<EmployeeType>("employeeEmail",
            arguments: new QueryArguments
            {
               new QueryArgument<StringGraphType> { Name = "email" },
               new QueryArgument<StringGraphType> { Name = "password" }
            }, 
            resolve: context =>
            {
               string email = context.GetArgument<string>("email");
               string password = context.GetArgument<string>("password");
               return _employeeData.GetByEmailPasswordAsync(email,password);
            });


//ROLES
         Field<ListGraphType<RoleType>>("roles", resolve: context =>
         {
            return _roleData.GetAllAsync();
         });

         Field<RoleType>("role",
            arguments: new QueryArguments
            {
               new QueryArgument<IntGraphType> { Name = "id" }
            }, 
            resolve: context =>
            {
               int id = context.GetArgument<int>("id");
               return _roleData.GetAsync(id);
            });

//PERMISSIONS
         Field<ListGraphType<PermissionType>>("permissions", resolve: context =>
         {
            return _permissionData.GetAllAsync();
         });

         Field<PermissionType>("permission",
            arguments: new QueryArguments
            {
               new QueryArgument<IntGraphType> { Name = "id" }
            }, 
            resolve: context =>
            {
               int id = context.GetArgument<int>("id");
               return _permissionData.GetAsync(id);
            });
            
// TASKS
         Field<ListGraphType<TaskType>>("tasks", resolve: context =>
         {
            return _taskData.GetAllAsync();
         });
      
         Field<TaskType>("task",
            arguments: new QueryArguments
            {
               new QueryArgument<IntGraphType> { Name = "id" }
            }, 
            resolve: context =>
            {
               int id = context.GetArgument<int>("id");
               return _taskData.GetAsync(id);
            });

// CATEGORIES
         Field<ListGraphType<CategoryType>>("categories", resolve: context =>
         {
            return _categoryData.GetAllAsync();
         });
      
         Field<CategoryType>("category",
            arguments: new QueryArguments
            {
               new QueryArgument<IntGraphType> { Name = "id" }
            }, 
            resolve: context =>
            {
               int id = context.GetArgument<int>("id");
               return _categoryData.GetAsync(id);
            });
      }
   }
}