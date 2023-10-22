
using LearnChat.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

namespace LearnChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(
                options =>
                options.MimeTypes = ResponseCompressionDefaults
                .MimeTypes
                .Concat(new[] { "application/octet-stream" }));
            var app = builder.Build();

            app.UseResponseCompression();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHub<ChatHub>("/LearnChat");

            app.MapControllers();

            app.Run();
        }
    }
}