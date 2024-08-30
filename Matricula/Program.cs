using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Matricula.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");


    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting(); // Habilita o roteamento, que define como as URLs sãomapeadas para as ações.
app.UseAuthorization(); // Habilita a autorização, garantindo que o acesso arecursos seja controlado.
// Mapeia as páginas Razor para os endpoints no aplicativo.
app.MapRazorPages();
// Testa a conexão com o banco de dados antes de executar o aplicativo.
TestDatabaseConnection(app);
// Inicia a aplicação web.
app.Run();
// Função que testa a conexão com o banco de dados.
void TestDatabaseConnection(WebApplication app)
{
    // Cria um escopo para obter os serviços do container de dependência.
    using (var scope = app.Services.CreateScope())
    {

        var services = scope.ServiceProvider;
        try
        {
            // Obtém o contexto de banco de dados injetado.
            var context =
            services.GetRequiredService<ApplicationDbContext>();
            // Verifica se é possível conectar ao banco de dados.
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connection to the database successful!");
                // Conexão bem-sucedida.
            }
            else
            {
                Console.WriteLine("Failed to connect to the database."); //Falha na conexão.

            }
        }
        catch (Exception ex)
        {
            // Captura qualquer exceção e imprime uma mensagem de erro.
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}