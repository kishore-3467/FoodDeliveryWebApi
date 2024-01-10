//Description:FoodDeliveryApplication
//Created By:Kishore V V 
//Created On:12/06/2023
//Update On:22/12/2023
//Reviewed by:
//Reviewd on:
using Microsoft.EntityFrameworkCore;
using FoodDeliveryAppWA.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
//using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Congigure Controller
builder.Services.AddControllers();
#endregion
#region Congigure Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion
#region Congigure Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion
/*#region Congigure Loggers
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
#endregion*/
#region Congigure Swagger Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
//app.UseSerilogRequestLogging(); 

//Additional endpoints if needed
app.UseEndpoints(endpoints =>
{
    // Map Swagger JSON endpoint
    endpoints.MapSwagger();
    // Map API endpoints
    endpoints.MapControllers();
    // Additional endpoints
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}");
});
app.Run();
