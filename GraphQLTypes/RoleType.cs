using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class RoleType:ObjectGraphType<Role>
   {
      public RoleType()
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.PermissionId);
      }
   }

   public class InputRoleType:InputObjectGraphType<Role>
   {
      public InputRoleType()
      {
         Name = "InputRoleType";
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.PermissionId);
      }
   }
}