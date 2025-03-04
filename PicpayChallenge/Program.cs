using Microsoft.EntityFrameworkCore;
using PicpayChallenge.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PicpayChallengeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();