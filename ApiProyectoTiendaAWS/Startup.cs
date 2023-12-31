using Amazon.S3;
using ApiProyectoTienda.Repositories;
using ApiProyectoTiendaAWS.Data;
using ApiProyectoTiendaAWS.Helpers;
using ApiProyectoTiendaAWS.Models;
using ApiProyectoTiendaAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiProyectoTiendaAWS;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {

        string connectionString =
            this.Configuration.GetConnectionString("MySqlTienda");

        string secrets =
            HelperSecretManager.GetSecretAsync().Result;
        KeysModel model = JsonConvert.DeserializeObject<KeysModel>(secrets);

        services.AddTransient<RepositoryArtista>();
        services.AddTransient<RepositoryCliente>();
        services.AddTransient<RepositoryInfoArte>();

        //services.AddDbContext<ProyectoTiendaContext>
        //    (options => options.UseMySql(connectionString
        //    , ServerVersion.AutoDetect(connectionString)));


        services.AddDbContext<ProyectoTiendaContext>
            (options => options.UseMySql(model.MySqlTienda
            , ServerVersion.AutoDetect(model.MySqlTienda)));

        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin());
        });

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api AWS TIENDA ",
                Version = "v1"
                ,
                Description = "Api TIENDA AWS"



            });
        });

        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(options => options.AllowAnyOrigin());

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("swagger/v1/swagger.json"
                , "Api AWS TIENDA v1");
            options.RoutePrefix = "";
        });

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}