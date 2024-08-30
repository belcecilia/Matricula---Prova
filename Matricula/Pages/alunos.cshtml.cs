using Matricula.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.Collections.Generic;
using System.Threading.Tasks;
public class alunosModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public alunosModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Student> Students { get; set; }

    public async Task OnGetAsync()
    {
        Students = await _context.Students.ToListAsync();

    }
    public async Task<IActionResult> OnPostAddAsync(Student newStudent)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        return RedirectToPage();
    }


}