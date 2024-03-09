using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace App.Extensions;

public static class AppExtensions
{
    public static IApplicationBuilder UsarCulturaEspecifica(this IApplicationBuilder app, string cultura)
    {
        var supportedCultures = new[] { new CultureInfo(cultura) };
        
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(culture: cultura, uiCulture: cultura),
            SupportedCultures = supportedCultures,
            SupportedUICultures = supportedCultures
        });

        return app;
    }
}
