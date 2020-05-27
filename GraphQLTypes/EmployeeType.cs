using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class EmployeeType:ObjectGraphType<Employee>
   {
      public EmployeeType()
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