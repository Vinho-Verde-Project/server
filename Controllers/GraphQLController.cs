using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Newtonsoft.Json;

namespace Api.Controllers
{
   [Route("graphql")]
   [ApiController]
   public class GraphQLController : Controller
   {
      private readonly ISchema _schema;

      public GraphQLController(ISchema schema)
      {
         _schema = schema;
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] GraphQLQueryDto query)
      {
         var result = await new DocumentExecuter().ExecuteAsync(_ =>
         {
            _.Schema = _schema;
            _.Query = query.Query;
            _.Inputs = query.Variables?.ToInputs();
         }).ConfigureAwait(false);

         if (result.Errors?.Count > 0)
         {
            return Problem(detail: result.Errors.Select(_ => _.Message).FirstOrDefault(), statusCode: 500);
         }
         return Ok(result.Data);
      }
   }
}
