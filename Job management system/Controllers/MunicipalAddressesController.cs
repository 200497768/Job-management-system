
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_management_system.Models;
using Job_management_system.Data;

public class MunicipalAddressesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MunicipalAddressesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: MUNICIPALADDRESSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.MunicipalAddress.ToListAsync());
    }

    // GET: MUNICIPALADDRESSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var municipaladdress = await _context.MunicipalAddress
            .FirstOrDefaultAsync(m => m.Id == id);
        if (municipaladdress == null)
        {
            return NotFound();
        }

        return View(municipaladdress);
    }

    // GET: MUNICIPALADDRESSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MUNICIPALADDRESSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Description,Number,StreetName,City,Province")] MunicipalAddress municipaladdress)
    {
        if (ModelState.IsValid)
        {
            _context.Add(municipaladdress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(municipaladdress);
    }

    // GET: MUNICIPALADDRESSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var municipaladdress = await _context.MunicipalAddress.FindAsync(id);
        if (municipaladdress == null)
        {
            return NotFound();
        }
        return View(municipaladdress);
    }

    // POST: MUNICIPALADDRESSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Description,Number,StreetName,City,Province")] MunicipalAddress municipaladdress)
    {
        if (id != municipaladdress.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(municipaladdress);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipalAddressExists(municipaladdress.Id))
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
        return View(municipaladdress);
    }

    // GET: MUNICIPALADDRESSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var municipaladdress = await _context.MunicipalAddress
            .FirstOrDefaultAsync(m => m.Id == id);
        if (municipaladdress == null)
        {
            return NotFound();
        }

        return View(municipaladdress);
    }

    // POST: MUNICIPALADDRESSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var municipaladdress = await _context.MunicipalAddress.FindAsync(id);
        if (municipaladdress != null)
        {
            _context.MunicipalAddress.Remove(municipaladdress);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MunicipalAddressExists(int? id)
    {
        return _context.MunicipalAddress.Any(e => e.Id == id);
    }
}
