using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;
using PicpayChallenge.Data.Repositories;
using PicpayChallenge.Data.Repositories.Interfaces;
using PicpayChallenge.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PicpayChallengeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWalletRepository, WalletRepository>();


var app = builder.Build();
app.AddWalletEndPoints();

app.Run();