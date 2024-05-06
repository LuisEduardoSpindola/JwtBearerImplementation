using JwtBearerImplementation.Services.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenServices>();

var app = builder.Build();

app.MapGet("/", (TokenServices services) => services.generateToken(null));

app.Run();
