using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class EmployeeType:ObjectGraphType<Employee>
   {
      public EmployeeType(IRoleData _roleData)
      {
         Field(_ => _.Id);
         Field(_ => _.Username);
         Field(_ => _.FirstName);
         Field(_ => _.LastName);
         Field(_ => _.Nif);
         Field(_ => _.Birthdate);
         Field(_ => _.Adress);
         Field(_ => _.Phone);
         Field(_ => _.Email);
         Field(_ => _.HashedPassword);
         Field(_ => _.CreatedAt);
         Field(_ => _.RoleId);
         Field<RoleType>(
            "role",
            resolve: context => _roleData.GetAsync(context.Source.RoleId));
      }
   }

   public class InputEmployeeType:InputObjectGraphType<Employee>
   {
      public InputEmployeeType()
      {
         Name = "InputEmployeeType";
         Field(_ => _.Id);
         Field(_ => _.Username);
         Field(_ => _.FirstName);
         Field(_ => _.LastName);
         Field(_ => _.Nif);
         Field(_ => _.Birthdate);
         Field(_ => _.Adress);
         Field(_ => _.Phone);
         Field(_ => _.Email);
         Field(_ => _.HashedPassword);
         Field(_ => _.CreatedAt);
         Field(_ => _.RoleId);
      }
   }
}