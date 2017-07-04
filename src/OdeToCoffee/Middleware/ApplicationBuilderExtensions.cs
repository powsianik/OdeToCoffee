using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = new PhysicalFileProvider(Path.Combine(root, "node_modules"));
            app.UseStaticFiles(options);

            return app;
        }
    }
}