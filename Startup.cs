using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.GraphQLTypes;
using GraphQL;
using GraphQL.Types;
using GraphQL.Server.Ui.Playground;
using System;
using System.Threading;
using System.Text.Json;

namespace Api
{
   public class Startup
   {
      readonly string _allowSpecificOrigins = "AllowSpecificOrigins";
      private readonly string _admConnectionString;
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
         _admConnectionString = $@"Server=adm_db; Database={Configuration["POSTGRES_DB"]}; Uid={Configuration["POSTGRES_USER"]}; Pwd={Configuration["POSTGRES_PASSWORD"]}";
      }

      public IConfiguration Configuration { get; }

      public void ConfigureServices(IServiceCollection services)
      {
         services.AddRouting(options => options.LowercaseUrls = true);
         services.AddControllers().AddJsonOptions(options =>
         {
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.IgnoreNullValues = true;
         });
         services.AddHostedService<MigratorHostedService>();

         services.AddCors(options =>
         {
            options.AddPolicy(_allowSpecificOrigins,
               builder =>
               {
                  builder.AllowAnyOrigin()
                                         .AllowAnyHeader()
                                         .AllowAnyMethod();
               });
         });

         services.AddDbContext<AdmContext>(options =>
         {
            options.UseNpgsql(_admConnectionString);
         });

         services.AddSingleton<WineType>();
         services.AddSingleton<InputWineType>();
         services.AddSingleton<PermissionType>();
         services.AddSingleton<InputPermissionType>();
         services.AddSingleton<EmployeeType>();
         services.AddSingleton<InputEmployeeType>();
         services.AddSingleton<RoleType>();
         services.AddSingleton<InputRoleType>();
         services.AddSingleton<TaskType>();
         services.AddSingleton<InputTaskType>();
         services.AddSingleton<CategoryType>();
         services.AddSingleton<InputCategoryType>();

         services.AddScoped<ICategoryData, CategoryData>();
         services.AddScoped<IEmployeeData, EmployeeData>();
         services.AddScoped<IPermissionData, PermissionData>();
         services.AddScoped<IRoleData, RoleData>();
         services.AddScoped<IStepData, StepData>();
         services.AddScoped<ITaskData, TaskData>();
         services.AddScoped<IWineData, WineData>();
         services.AddScoped<RootQuery>();
         services.AddScoped<RootMutation>();
         services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
         services.AddScoped<ISchema, RootSchema>();
      }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdmContext admContext)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         app.UseCors(_allowSpecificOrigins);
         try
         {
            Console.WriteLine("Trying to connect to database...");
            int retries = 1;
            while (retries < 7)
            {
               try
               {
                  Console.WriteLine("Connecting to database. Trial: {0}", retries);
                  admContext.Database.MigrateAsync().GetAwaiter().GetResult();
                  break;
               }
               catch
               {
                  Thread.Sleep((int)Math.Pow(2, retries) * 1000);
                  retries++;
               }
            }
            Console.WriteLine("Database connected successfully.");
         }
         catch (Exception e)
         {
            Console.WriteLine("An error occurred when trying to connect to database. Error: {}.", e);
         }

         var optionsBuilder = new DbContextOptionsBuilder<AdmContext>();
         optionsBuilder.UseNpgsql(_admConnectionString);
         using (var context = new AdmContext(optionsBuilder.Options))
         {
            context.Database.Migrate();
         }

         app.UseHttpsRedirection();

         app.UseRouting();

         app.UseAuthorization();

         app.UseStaticFiles();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });

         app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());  
      }
      //private static void InitializeMapper()
      //{
      //Mapper.Initialize(x =>
      //{
      //   x.CreateMap<User, UserModel>();
      //});
      //}
   }
}
