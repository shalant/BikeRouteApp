using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeRouteApp.Data;
using BikeRouteApp.Models;

namespace BikeRouteApp.Controllers
{
    public class BikeRoutesController : Controller
    {
        private readonly BikeRouteAppContext _context;

        public BikeRoutesController(BikeRouteAppContext context)
        {
            _context = context;
        }

        // GET: BikeRoutes
        public async Task<IActionResult> Index(string BikeRouteDirection, string searchString)
        {
            if (_context.BikeRoute == null)
            {
                return Problem("Entity set 'BikeRouteAppContext.BikeRoute'  is null.");
            }

            // Use LINQ to get list of directions.
            IQueryable<string> directionQuery = from b in _context.BikeRoute
                                            orderby b.Direction
                                            select b.Direction;
            var bikeRoutes = from b in _context.BikeRoute
                         select b;


            if (!String.IsNullOrEmpty(searchString))
            {
                bikeRoutes = bikeRoutes.Where(s => s.Name!.Contains(searchString));
            }

            var bikeRouteVM = new BikeRouteDirectionViewModel
            {
                Directions = new SelectList(await directionQuery.Distinct().ToListAsync()),
                BikeRoutes = await bikeRoutes.ToListAsync()
            };

            return View(bikeRouteVM);

            return View(await bikeRoutes.ToListAsync());
            //return _context.BikeRoute != null ? 
            //              View(await _context.BikeRoute.ToListAsync()) :
            //              Problem("Entity set 'BikeRouteAppContext.BikeRoute'  is null.");
        }

        // GET: BikeRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BikeRoute == null)
            {
                return NotFound();
            }

            var bikeRoute = await _context.BikeRoute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikeRoute == null)
            {
                return NotFound();
            }

            return View(bikeRoute);
        }

        // GET: BikeRoutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BikeRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Length,Elevation,Direction,Description,StravaLink,MapUrl")] BikeRoute bikeRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bikeRoute);
        }

        // GET: BikeRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BikeRoute == null)
            {
                return NotFound();
            }

            var bikeRoute = await _context.BikeRoute.FindAsync(id);
            if (bikeRoute == null)
            {
                return NotFound();
            }
            return View(bikeRoute);
        }

        // POST: BikeRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Length,Elevation,Direction,Description,StravaLink,MapUrl")] BikeRoute bikeRoute)
        {
            if (id != bikeRoute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeRouteExists(bikeRoute.Id))
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
            return View(bikeRoute);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: BikeRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BikeRoute == null)
            {
                return NotFound();
            }

            var bikeRoute = await _context.BikeRoute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bikeRoute == null)
            {
                return NotFound();
            }

            return View(bikeRoute);
        }

        // POST: BikeRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BikeRoute == null)
            {
                return Problem("Entity set 'BikeRouteAppContext.BikeRoute'  is null.");
            }
            var bikeRoute = await _context.BikeRoute.FindAsync(id);
            if (bikeRoute != null)
            {
                _context.BikeRoute.Remove(bikeRoute);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeRouteExists(int id)
        {
          return (_context.BikeRoute?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
