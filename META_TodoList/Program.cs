using Microsoft.AspNetCore.Authentication.JwtBearer;
using META_TodoList.Setup;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using META_TodoList.Models.Jwt_Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using META_TodoList;
using META_TodoList.Services.DapperDB.ToDoList_Service;
using META_TodoList.Services.DapperDB.User_Service;
using META_TodoList.Services.EFDBcontext.User_EF_Service;
using META_TodoList.Data.cs.EF;
using META_TodoList.Services;
using META_TodoList.Services.EFDBcontext.ToDoList_EF_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserEF>();
builder.Services.AddScoped<IToDoList, ToDoListEF>();
builder.Services.AddSingleton<IProviderJwt, ProviderJwt>();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(o =>
{
	o.DefaultScheme = "Jwt_or_Cookie";
	o.DefaultChallengeScheme = "Jwt_or_Cookie";
})
	.AddCookie("Cookies", options =>
	{
		options.LoginPath = "/User/SignIn";
		options.ReturnUrlParameter = "/User/UserIndex";
		options.ExpireTimeSpan = TimeSpan.FromDays(1);
	})
	.AddJwtBearer("Bearer")
	.AddPolicyScheme("Jwt_or_Cookie", "Jwt_or_Cookie", options =>
 {
	 // runs on each request
	 options.ForwardDefaultSelector = context =>
	 {
		 // filter by auth type
		 string authorization = context.Request.Headers[HeaderNames.Authorization];
		 if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer"))
			 return JwtBearerDefaults.AuthenticationScheme;

		 // otherwise always check for cookie auth
		 return CookieAuthenticationDefaults.AuthenticationScheme;
	 };
 });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
