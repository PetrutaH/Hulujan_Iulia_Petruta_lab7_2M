using GrpcCustomersService.Services;
using Microsoft.EntityFrameworkCore;
using Hulujan_Iulia_Petruta_Lab2M.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Hulujan_Iulia_Petruta_Lab2MContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Hulujan_Iulia_Petruta_Lab2MContext")));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcCRUDService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
