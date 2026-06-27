
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_management_system.Models;
using Job_management_system.Data;

public class OfficesController : Controller
{
    private readonly ApplicationDbContext _context;

    public OfficesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: OFFICES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Office.ToListAsync());
    }

    // GET: OFFICES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var office = await _context.Office
            .FirstOrDefaultAsync(m => m.Id == id);
        if (office == null)
        {
            return NotFound();
        }

        return View(office);
    }

    // GET: OFFICES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: OFFICES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,MunicipalAddress")] Office office)
    {
        if (ModelState.IsValid)
        {
            _context.Add(office);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(office);
    }

    // GET: OFFICES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var office = await _context.Office.FindAsync(id);
        if (office == null)
        {
            return NotFound();
        }
        return View(office);
    }

    // POST: OFFICES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,MunicipalAddress")] Office office)
    {
        if (id != office.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(office);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(office.Id))
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
        return View(office);
    }

    // GET: OFFICES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var office = await _context.Office
            .FirstOrDefaultAsync(m => m.Id == id);
        if (office == null)
        {
            return NotFound();
        }

        return View(office);
    }

    // POST: OFFICES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var office = await _context.Office.FindAsync(id);
        if (office != null)
        {
            _context.Office.Remove(office);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool OfficeExists(int? id)
    {
        return _context.Office.Any(e => e.Id == id);
    }
}
