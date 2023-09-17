﻿using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;

namespace Abc.Northwind.MvcWebUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;
            app.UseStaticFiles(options);
            return app;
        }
    }
}
