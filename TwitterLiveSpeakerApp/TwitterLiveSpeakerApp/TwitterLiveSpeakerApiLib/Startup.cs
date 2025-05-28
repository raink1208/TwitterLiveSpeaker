using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TwitterLiveSpeakerApiLib.Infrastructure.VoiceBox;
using TwitterLiveSpeakerApiLib.Services;
using TwitterLiveSpeakerApiLib.SignalR;

namespace TwitterLiveSpeakerApiLib
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            services.AddHttpClient();
            services.AddSignalR();

            services.AddSingleton<SpeakerService>();

            services.AddSingleton<VoiceBoxClient>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SpeakerAppHub>("/speakerAppHub");
            });
        }
    }
}