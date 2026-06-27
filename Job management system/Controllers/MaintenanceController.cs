
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_management_system.Models;
using Job_management_system.Data;

public class MaintenanceController : Controller
{
    private readonly ApplicationDbContext _context;

    public MaintenanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MAINTENANCES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Maintenance.ToListAsync());
    }

    // GET: MAINTENANCES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maintenance = await _context.Maintenance
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maintenance == null)
        {
            return NotFound();
        }

        return View(maintenance);
    }

    // GET: MAINTENANCES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MAINTENANCES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id")] Maintenance maintenance)
    {
        if (ModelState.IsValid)
        {
            _context.Add(maintenance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(maintenance);
    }

    // GET: MAINTENANCES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maintenance = await _context.Maintenance.FindAsync(id);
        if (maintenance == null)
        {
            return NotFound();
        }
        return View(maintenance);
    }

    // POST: MAINTENANCES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id")] Maintenance maintenance)
    {
        if (id != maintenance.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(maintenance);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceExists(maintenance.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(maintenance);
    }

    // GET: MAINTENANCES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var maintenance = await _context.Maintenance
            .FirstOrDefaultAsync(m => m.Id == id);
        if (maintenance == null)
        {
            return NotFound();
        }

        return View(maintenance);
    }

    // POST: MAINTENANCES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var maintenance = await _context.Maintenance.FindAsync(id);
        if (maintenance != null)
        {
            _context.Maintenance.Remove(maintenance);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MaintenanceExists(int? id)
    {
        return _context.Maintenance.Any(e => e.Id == id);
    }
}
