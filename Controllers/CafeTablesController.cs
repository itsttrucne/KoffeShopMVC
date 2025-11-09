using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBanNuocMVC.Data;

namespace WebBanNuocMVC.Controllers
{
    public class CafeTablesController : Controller
    {
        private readonly CoffeeShopDbContext _context;

        public CafeTablesController(CoffeeShopDbContext context)
        {
            _context = context;
        }

        // GET: CafeTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.CafeTables.ToListAsync());
        }

        // GET: CafeTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeTable = await _context.CafeTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (cafeTable == null)
            {
                return NotFound();
            }

            return View(cafeTable);
        }

        // GET: CafeTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CafeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,TableName,Status")] CafeTable cafeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafeTable);
        }

        // GET: CafeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeTable = await _context.CafeTables.FindAsync(id);
            if (cafeTable == null)
            {
                return NotFound();
            }
            return View(cafeTable);
        }

        // POST: CafeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableId,TableName,Status")] CafeTable cafeTable)
        {
            if (id != cafeTable.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeTableExists(cafeTable.TableId))
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
            return View(cafeTable);
        }

        // GET: CafeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeTable = await _context.CafeTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (cafeTable == null)
            {
                return NotFound();
            }

            return View(cafeTable);
        }

        // POST: CafeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeTable = await _context.CafeTables.FindAsync(id);
            if (cafeTable != null)
            {
                _context.CafeTables.Remove(cafeTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeTableExists(int id)
        {
            return _context.CafeTables.Any(e => e.TableId == id);
        }
    }
}
