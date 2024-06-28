
using FinTechProjectAPI.API.Configurations;
using FinTechProjectAPI.Application.Extensions;
using FinTechProjectAPI.Application.Features.AppUsers.Commands.Login;
using FinTechProjectAPI.Infrastructure.Extensions;
using FinTechProjectAPI.Persistence.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Text;

namespace FinTechProjectAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.addInfrastructureServices();
            builder.Services.AddCors();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            SqlColumn sqlColumn = new SqlColumn();
            sqlColumn.ColumnName = "UserName";
            sqlColumn.DataType = System.Data.SqlDbType.NVarChar;
            sqlColumn.PropertyName = "UserName";
            sqlColumn.DataLength = 50;
            sqlColumn.AllowNull = true;
            ColumnOptions columnOpt = new ColumnOptions();
            columnOpt.Store.Remove(StandardColumn.Properties);
            columnOpt.Store.Add(StandardColumn.LogEvent);
            columnOpt.AdditionalColumns = new Collection<SqlColumn> { sqlColumn };



            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt")
                .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("MSSQL")
                , sinkOptions: new MSSqlServerSinkOptions
                {
                    AutoCreateSqlTable = true,
                    TableName = "Logs",


                }, appConfiguration: null,
                columnOptions: columnOpt
                )
                .Enrich.FromLogContext()
                .Enrich.With<CustomUserNameColumn>()
                .MinimumLevel.Information()
                .CreateLogger();
            builder.Host.UseSerilog(log);

            //JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("adm", opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidAudience = builder.Configuration["Token:Audience"],
                    ValidIssuer = builder.Configuration["Token:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                    NameClaimType = ClaimTypes.Name,
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            
            app.Use(async (context, next) =>
            {
                var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
                LogContext.PushProperty("UserName", username);
                await next();
            });
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/api/auth/login") && context.Request.Method == HttpMethods.Post)
                {
                    // Burada istediðiniz iþlemi gerçekleþtirebilirsiniz
                    context.Request.EnableBuffering(); // Enable buffering

                    // Kullanýcý adýný JSON gövdesinden alýyoruz
                    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
                    context.Request.Body.Position = 0; // Reset the stream position

                    var loginRequest = JsonConvert.DeserializeObject<LoginUserCommandRequest>(requestBody);
                    var username = loginRequest?.UserNameOrEmail;

                    if (!string.IsNullOrEmpty(username))
                    {
                        // Kullanýcý adýný LogContext'e ekleyin
                        LogContext.PushProperty("UserName", username);

                        // Kullanýcý giriþini loglayýn

                    }
                }
                await next();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
