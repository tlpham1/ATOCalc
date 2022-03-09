namespace ATOCalc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) { }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Test Complete");
            });
        }
    }
}
