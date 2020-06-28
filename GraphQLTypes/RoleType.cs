using GraphQL.Types;
using Api.Models;
using Api.Data;

namespace Api.GraphQLTypes
{
   public class RoleType:ObjectGraphType<Role>
   {
      public RoleType(IPermissionData _permissionData)
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);
         Field(_ => _.PermissionId);
         Field<PermissionType>(
            "permission",
            resolve: context => _permissionData.GetAsync(context.Source.PermissionId));
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