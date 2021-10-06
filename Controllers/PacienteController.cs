using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context; 
        public PacienteController(TurnosContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _context.Paciente.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p=>p.IdPaciente == id);

            if(paciente is null)
            {
                return NotFound();
            }

            return View(paciente);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if(ModelState.IsValid)
            {
                await _context.Paciente.AddAsync(paciente);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }

            var paciente  = await _context.Paciente.FindAsync(id);

            if(paciente is null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Paciente paciente,int id)
        {   
            if(id != paciente.IdPaciente)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Paciente.Update(paciente);

                await _context.SaveChangesAsync();

               return  RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(x=>x.IdPaciente == id);

            if(paciente is null)
            {
                return NotFound();
            }
            return View(paciente);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FirstOrDefaultAsync(x=>x.IdPaciente == id);

            if(paciente is null)
            {
                return NotFound();
            }
            _context.Paciente.Remove(paciente);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}