using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Janos_Nagy_Lab2.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options => 
{ 
    options.AddPolicy("AdminPolicy", policy => 
    policy.RequireRole("Admin")); 
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{ 
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/Members", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Publishers", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Categories", "AdminPolicy");
});

builder.Services.AddDbContext<Janos_Nagy_Lab2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Janos_Nagy_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Janos_Nagy_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Janos_Nagy_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Janos_Nagy_Lab2Context' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
