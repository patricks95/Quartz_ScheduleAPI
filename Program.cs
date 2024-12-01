using Auto_API_Run;
using Quartz;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApiService>();

// Add Quartz services
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    // Define a job
    var jobKey = new JobKey("DailyApiJob");
    q.AddJob<ApiJob>(opts => opts.WithIdentity(jobKey));

    // Schedule the job to run daily at 8:00 AM
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DailyApiTrigger")
        .WithCronSchedule("0 * * * * ?")); // CRON expression for 8:00 AM daily
});

// Register Quartz as a hosted service
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

// Add HTTP client for API calls
builder.Services.AddHttpClient<ApiService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
