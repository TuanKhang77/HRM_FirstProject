using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using QuanLyNhanSu.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    //view/controller/action.cshtml
    //myview/controller/action.cshtml
    //cần add 1 cấu trúc thư mục
    // {0} -> ten action
    // {1} -> ten controller
    // {2} -> ten area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// khi lấy dịch vụ product service thì tạo ra đối tượng product service
//builder.Services.AddSingleton<ProductService>();
//// tạo ra dịch vụ product service và đối tượng triển khai của nó là product service
//builder.Services.AddSingleton<ProductService, ProductService>();
//// tạo ra dịch vụ có tên là typeof(productservice), khi dịch vụ này dc tạo ra thì nó tạo ra
//// đối tượng là product service




var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "MyView")
    // Or some other absolute path. 
    )
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");
    endpoints.MapRazorPages();
});

app.Run();  
