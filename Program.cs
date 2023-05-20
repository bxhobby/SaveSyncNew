using Microsoft.EntityFrameworkCore;
using Radzen;
using SaveSyncNew.Data;
using SaveSyncNew.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ThaiDataService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddDbContext<DataContext>(Option => Option.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=CwCustomer;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=true;TrustServerCertificate=true;"));
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ShopService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
