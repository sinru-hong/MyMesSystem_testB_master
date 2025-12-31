using test_B.ModelServices;
using test_B.Services;

var builder = WebApplication.CreateBuilder(args);

// 註冊 ModelService 與 Service
builder.Services.AddScoped<ProductModelService>();
builder.Services.AddScoped<ProductService>();

// Add services to the container.
// 在 var builder = WebApplication.CreateBuilder(args); 之後加入
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// 找到這行：builder.Services.AddControllers();
// 修改成以下內容：
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // 這能確保 JSON 輸出時保持原始的大小寫，避免 Hashtable 的 Key 被強制改名
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 在 app.UseHttpsRedirection(); 之後加入
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
