
using F1RacersAPI.Data;
using F1RacersAPI.Services.F1RacersService;
using Microsoft.EntityFrameworkCore;

namespace F1RacersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IF1RacersService, F1RacersService>();
            builder.Services.AddControllers();
            builder.Services.AddDbContext<F1RacersDataContext>(options => 
                                        options.UseSqlServer("Server=DESKTOP-9225AUG\\SQLEXPRESS;Database=F1RacersDb; Trusted_Connection=True; TrustServerCertificate=True;"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}