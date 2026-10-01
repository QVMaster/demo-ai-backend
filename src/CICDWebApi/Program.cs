var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello !");

app.MapGet("/health", () => {
		
		  MainProcess prc = new MainProcess("Medium String is here.");
		  string remain = prc.CutEnd(6);
		  return $"Hi, I'm healthy with remained: {remain}";		
		});

app.MapGet("/cut/{cutNumber:int}", (int cutNumber) => {
		
		  MainProcess prc = new MainProcess("Medium String is here.");
		  string remain = prc.CutEnd(cutNumber);
		  return $"Hi, I'm healthy and cut with this remained: {remain}";		
		});

app.Run();



public class MainProcess
{
  private string _mainStr = string.Empty;

  public string MainStr => _mainStr;

  public MainProcess(string str)
  {
    _mainStr = str;	  
  }

  public string CutEnd(int howMuch)
  {
    if (howMuch > _mainStr.Length)
      throw new InvalidDataException("Tail can not be greater than whole string!");

    return _mainStr[..^howMuch];
  }
}

