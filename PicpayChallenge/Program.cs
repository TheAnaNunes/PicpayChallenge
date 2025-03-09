using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Repositories;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.EndPoints;
using PicpayChallenge.Services.Services;
using PicpayChallenge.Services.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PicpayChallengeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();  

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWalletService, WalletService>();

var app = builder.Build();
app.AddWalletEndPoints();
app.AddUserEndPoints();

app.Run();