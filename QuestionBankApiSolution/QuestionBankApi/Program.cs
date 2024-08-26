
using Microsoft.EntityFrameworkCore;
using QuestionBankApiLibrary.Data;
using QuestionBankApiLibrary.Services;

namespace QuestionBankApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add DbContext and Services
            builder.Services.AddDbContext<QuestionBankDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<IResultService, ResultService>();


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
