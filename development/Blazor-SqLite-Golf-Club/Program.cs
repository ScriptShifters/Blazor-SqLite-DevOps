// <copyright file="Program.cs" company="CodeApprover">
// Copyright (c) CodeApprover. All rights reserved.
// </copyright>

namespace Blazor_SqLite_Golf_Club
{
    using Blazor_SqLite_Golf_Club.Data;
    using Blazor_SqLite_Golf_Club.DbContext;
    using Blazor_SqLite_Golf_Club.Services;
    using Radzen;

    /// <summary>
    /// The main entry point for the Golf Club application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that serves as the entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();
            builder.Services.AddDbContext<DatabaseContext>();
            builder.Services.AddScoped<PlayerService>();
            builder.Services.AddScoped<GameService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
