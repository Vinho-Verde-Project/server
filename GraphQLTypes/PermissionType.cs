using GraphQL.Types;
using Api.Models;

namespace Api.GraphQLTypes
{
   public class PermissionType:ObjectGraphType<Permission>
   {
      public PermissionType()
      {
         Field(_ => _.Id);
         Field(_ => _.Desc);

      }
   }

   public class InputPermissionType:InputObjectGraphType<Permission>
   {
      public InputPermissionType()
      {
         Name = "InputPermissionType";
         Field(_ => _.Id);
         Field(_ => _.Desc);
      }
   }
}