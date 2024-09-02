using Microsoft.EntityFrameworkCore;
using Matricula.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os Razor Pages
builder.Services.AddRazorPages();

// Configura o DbContext para usar MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 0)))); // Corrigido aqui com par�ntese fechado e ponto e v�rgula

var app = builder.Build();

// Configura o pipeline de solicita��es
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Mapeia as p�ginas Razor para os endpoints no aplicativo
app.MapRazorPages();

// Testa a conex�o com o banco de dados
TestDatabaseConnection(app);

// Inicia a aplica��o web
app.Run();

// Fun��o que testa a conex�o com o banco de dados
void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            // Obt�m o contexto de banco de dados injetado
            var context = services.GetRequiredService<ApplicationDbContext>();
            // Verifica se � poss�vel conectar ao banco de dados
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connection to the database successful!");
            }
            else
            {
                Console.WriteLine("Failed to connect to the database.");
            }
        }
        catch (Exception ex)
        {
            // Captura qualquer exce��o e imprime uma mensagem de erro
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}
