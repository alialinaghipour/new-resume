var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddControllersWithViews();
services
    .AddIdentityFromFramework()
    .AddRouting()
    .AddHttpContextAccessor();

#region auto mapper

var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region Google Recaptcha

builder.Services.Configure<GoogleRecaptchaConfig>(configuration.GetSection(nameof(GoogleRecaptchaConfig)));
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
builder.Services.AddScoped<IGoogleRecaptchaValidator, GoogleRecaptchaValidator>();

#endregion

#region Encoder

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

builder.Host.AddAutofacConfigs(configuration);

var app = builder.Build();

app.UseHttpsRedirection()
    .UseEnvelopeConfigWeb()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();