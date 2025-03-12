using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Repositories;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.EndPoints;
using PicpayChallenge.Middleware;
using PicpayChallenge.Services.Services;
using PicpayChallenge.Services.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PicpayChallengeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<TransactionService>();

builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();  
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.AddWalletEndPoints();
app.AddUserEndPoints();
app.AddTransactionsEndPoints();

app.Run();