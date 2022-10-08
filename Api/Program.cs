using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolves.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();

//IOC
// builder.Services.AddSingleton<IOrderService,OrderManager>();
// builder.Services.AddSingleton<IOrderDal,EfOrderDal>();
//dotnet add package Autofac.Extensions.DependencyInjection --version 8.0.0


//Business katmanda ki autofac
builder.Host.UseServiceProviderFactory( new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>( builder => {
    builder.RegisterModule( new AutofacBusinessModule());
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
