using JobTrackerAPI.Repository;
using JobTrackerAPI.Repository.Data;
using JobTrackerAPI.Repository.Common;
using JobTrackerAPI.Repository.MappingProfiles;
using JobTrackerAPI.Service;
using JobTrackerAPI.Service.Common;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<JobRepository>().As<IJobRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<JobService>().As<IJobService>().InstancePerLifetimeScope();

    containerBuilder.RegisterType<InterviewRepository>().As<IInterviewRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<InterviewService>().As<IInterviewService>().InstancePerLifetimeScope();

    containerBuilder.RegisterType<StatsRepository>().As<IStatsRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<StatsService>().As<IStatsService>().InstancePerLifetimeScope();
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(Program), typeof(InterviewEntityProfile), typeof(JobEntityProfile));

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});



var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
