using GraphQLDemo.API.Schema.Mutations;
using GraphQLDemo.API.Schema.Qeries;
using GraphQLDemo.API.Schema.Subscriptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>()
    .AddMutationType<Mutattion>().AddSubscriptionType<Subscription>().AddInMemorySubscriptions();


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
