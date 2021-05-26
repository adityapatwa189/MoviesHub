using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspCoreAppWithTests.Models;
using Microsoft.AspNetCore.Http;

namespace AspCoreAppWithTests.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieApplicationContext _context;

        public MoviesController(MovieApplicationContext context)
        {
                _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("token") != null)
                return View(await _context.Movies.ToListAsync());
            return RedirectToAction("Login", "Admin");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movies
                    .FirstOrDefaultAsync(m => m.MovieId == id);
                if (movie == null)
                {
                    return NotFound();
                }

                return View(movie);
            }
            return RedirectToAction("Login", "Admin");
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("token") != null)
                return View();
            return RedirectToAction("Login", "Admin");
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,MovieName,ReleaseDate,Genre,MovieTime,Rating")] Movie movie)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(movie);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(movie);
            }
            return RedirectToAction("Login", "Admin");
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movies.FindAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return View(movie);
            }
            return RedirectToAction("Login", "Admin");
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,MovieName,ReleaseDate,Genre,MovieTime")] Movie movie)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                if (id != movie.MovieId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(movie);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MovieExists(movie.MovieId))
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
                return View(movie);
            }
            return RedirectToAction("Login", "Admin");
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("token") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var movie = await _context.Movies
                    .FirstOrDefaultAsync(m => m.MovieId == id);
                if (movie == null)
                {
                    return NotFound();
                }

                return View(movie);
            }
            return RedirectToAction("Login", "Admin");
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("token") != null) 
            {
                var movie = await _context.Movies.FindAsync(id);
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            return RedirectToAction("Login", "Admin");
        }

        public IActionResult Coupons()
        {
            return View();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
