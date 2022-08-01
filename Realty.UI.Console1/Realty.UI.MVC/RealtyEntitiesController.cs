using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Realty.Business;
using Realty.Entities;
using Realty.UI.MVC.Data;

namespace Realty.UI.MVC
{
    public class RealtyEntitiesController : Controller
    {
        private readonly RealtyUIMVCContext _context;

        public RealtyEntitiesController(RealtyUIMVCContext context)
        {
            _context = context;
        }

        // GET: RealtyEntities
        public IActionResult Index()
        {
            RealtyBsn realty = new RealtyBsn();
             return View(realty.GetAllRealtiesFromArea(1));
        }

        // GET: RealtyEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtyEntities = await _context.RealtyEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyEntities == null)
            {
                return NotFound();
            }

            return View(realtyEntities);
        }

        // GET: RealtyEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealtyEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SquareMeters,Price,ObjectType,SaleOrRent,PublishDate,ImageFilePath,Deleted")] RealtyEntities realtyEntities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realtyEntities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realtyEntities);
        }

        // GET: RealtyEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtyEntities = await _context.RealtyEntities.FindAsync(id);
            if (realtyEntities == null)
            {
                return NotFound();
            }
            return View(realtyEntities);
        }

        // POST: RealtyEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SquareMeters,Price,ObjectType,SaleOrRent,PublishDate,ImageFilePath,Deleted")] RealtyEntities realtyEntities)
        {
            if (id != realtyEntities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realtyEntities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtyEntitiesExists(realtyEntities.Id))
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
            return View(realtyEntities);
        }

        // GET: RealtyEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realtyEntities = await _context.RealtyEntities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyEntities == null)
            {
                return NotFound();
            }

            return View(realtyEntities);
        }

        // POST: RealtyEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realtyEntities = await _context.RealtyEntities.FindAsync(id);
            _context.RealtyEntities.Remove(realtyEntities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealtyEntitiesExists(int id)
        {
            return _context.RealtyEntities.Any(e => e.Id == id);
        }
    }
}
