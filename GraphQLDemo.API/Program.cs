using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Qeries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutattion>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Configure the Rrouting.. to run the project and get result in browser
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapGraphQL();
});

app.Run();
