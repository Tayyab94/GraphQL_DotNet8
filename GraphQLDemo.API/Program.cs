using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Qeries;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Services.Course;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>()
    .AddMutationType<Mutattion>().AddSubscriptionType<Subscription>().AddInMemorySubscriptions();

string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddPooledDbContextFactory<SchoolDbContext>(s => s.UseSqlite(connectionString));

builder.Services.AddScoped<CourseRepository>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Configure the Rrouting.. to run the project and get result in browser
app.UseRouting();
app.UseWebSockets();
app.UseWebSockets();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGraphQL();
});

app.Run();
