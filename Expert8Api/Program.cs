using expert8BL;
using Expert8BL;
using expert8DL;
using Expert8DL;
using Expert8Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(
    (options) => {
        options.AddDefaultPolicy(origin =>{

                origin.AllowAnyHeader(); //allows any http header to have access to backend
                origin.AllowAnyOrigin(); //allows any http verb request
                origin.AllowAnyMethod(); //allows any origin to talk to backend
    });
    }

);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Environment.GetEnvironmentVariable("Connection_String")
builder.Services.AddScoped<iexpert8DL<Patient>, patientDL>(repo => new patientDL(builder.Configuration.GetConnectionString("Connection String")));
builder.Services.AddScoped<ipatientBL, patientBL>();
builder.Services.AddScoped<iexpert8DL<JoinTable>, specialistDL>(repo => new specialistDL(builder.Configuration.GetConnectionString("Connection String")));
builder.Services.AddScoped<ispecialistBL, specialistBL>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
