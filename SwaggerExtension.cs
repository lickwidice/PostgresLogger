using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // c.SwaggerDoc("v1", new OpenApiInfo
            // {
            //     Version = "v1",
            //     Title = "My API",
            //     Description = "My First ASP.NET Core Web API",
            //     TermsOfService = new System.Uri("https://www.talkingdotnet.com"),
            //     Contact = new OpenApiContact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com" }
            // });
 
            // c.SwaggerDoc("v2", new OpenApiInfo
            // {
            //     Version = "v2",
            //     Title = "New API V2",
            //     Description = "Sample Web API",
            //     TermsOfService = new System.Uri("https://www.talkingdotnet.com"),
            //     Contact = new OpenApiContact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com" }
            // });
 
            // c.DescribeAllEnumsAsStrings();
            // c.DescribeStringEnumsInCamelCase();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
    }
    public static void UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
           //c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
        });
    }
}