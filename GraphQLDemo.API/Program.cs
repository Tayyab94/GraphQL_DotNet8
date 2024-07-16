using GraphQLDemo.API.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Configure the Rrouting.. to run the project and get result in browser
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGraphQL();
});

app.Run();
