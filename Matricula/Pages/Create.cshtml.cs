using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Matricula.Models;
using Microsoft.EntityFrameworkCore;

namespace Matricula.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Students.Add(Student);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Captura detalhes adicionais do erro
                ModelState.AddModelError("", $"Ocorreu um erro ao salvar: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
