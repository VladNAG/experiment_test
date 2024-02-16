
using experiment_test.Data;
using experiment_test.Data.Repository;
using experiment_test.Interfeces;
using experiment_test.Servises;
using Microsoft.EntityFrameworkCore;

namespace experiment_test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataProviderDbContent>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddTransient<IServise, ExperimentServise>();
            builder.Services.AddTransient<IResultRepository, ResultRepository>();
            builder.Services.AddTransient<IExperimetRepository, ExperimetRepository>();
            builder.Services.AddTransient<IDeviseRepository, DeviseRepository>();

            builder.Services.AddCors();

            builder.Services.AddControllers();
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