using AppBuenaAventura.Contexto;
using Microsoft.EntityFrameworkCore;
namespace AppBuenaAventura
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BuenaAventuraContext>(
            options =>
            {
                string CadenaCO = builder.Configuration.GetConnectionString("ConexionBuenaAventura");
                options.UseSqlServer(CadenaCO);

                builder.Services.AddOpenApi();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
