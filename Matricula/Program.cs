using Microsoft.EntityFrameworkCore;
using Matricula.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços Razor Pages
builder.Services.AddRazorPages();

// Configura o DbContext para usar MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 0)))); // Corrigido aqui com parêntese fechado e ponto e vírgula

var app = builder.Build();

// Configura o pipeline de solicitações
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Mapeia as páginas Razor para os endpoints no aplicativo
app.MapRazorPages();

// Testa a conexão com o banco de dados
TestDatabaseConnection(app);

// Inicia a aplicação web
app.Run();

// Função que testa a conexão com o banco de dados
void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            // Obtém o contexto de banco de dados injetado
            var context = services.GetRequiredService<ApplicationDbContext>();
            // Verifica se é possível conectar ao banco de dados
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
            // Captura qualquer exceção e imprime uma mensagem de erro
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}
