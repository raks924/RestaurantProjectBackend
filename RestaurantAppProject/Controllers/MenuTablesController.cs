using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAppProject.Models;

namespace RestaurantAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly restaurant_appContext _context;

        public MenuTablesController(restaurant_appContext context)
        {
            _context = context;
        }

        // GET: api/MenuTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuTable>>> GetMenuTables()
        {
          if (_context.MenuTables == null)
          {
              return NotFound();
          }
            return await _context.MenuTables.ToListAsync();
        }

        // GET: api/MenuTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuTable>> GetMenuTable(int id)
        {
          if (_context.MenuTables == null)
          {
              return NotFound();
          }
            var menuTable = await _context.MenuTables.FindAsync(id);

            if (menuTable == null)
            {
                return NotFound();
            }

            return menuTable;
        }

        // PUT: api/MenuTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuTable(int id, MenuTable menuTable)
        {
            if (id != menuTable.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menuTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MenuTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuTable>> PostMenuTable(MenuTable menuTable)
        {
          if (_context.MenuTables == null)
          {
              return Problem("Entity set 'restaurant_appContext.MenuTables'  is null.");
          }
            _context.MenuTables.Add(menuTable);
            try
            {
                await _context.SaveChangesAsync();

                //List<CategoryTable>
            }
            catch (DbUpdateException)
            {
                if (MenuTableExists(menuTable.MenuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMenuTable", new { id = menuTable.MenuId }, menuTable);
        }

        // DELETE: api/MenuTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuTable(int id)
        {
            if (_context.MenuTables == null)
            {
                return NotFound();
            }
            var menuTable = await _context.MenuTables.FindAsync(id);
            if (menuTable == null)
            {
                return NotFound();
            }

            List<MenuTable> menutables = await _context.MenuTables.ToListAsync();
            foreach (var menuitem in menutables)
            {
                if (menuitem.MenuId == id && menuitem.IsDeleted == false)
                {
                    menuitem.IsDeleted = true;
                    _context.MenuTables.Update(menuitem);
                    _context.SaveChanges();
                }
            }

            //Menu deletion -> menu category deletion -> category deletion
            List<MenuCategory> menuCategories = await _context.MenuCategories.ToListAsync();
            List<CategoryTable> catetables = await _context.CategoryTables.ToListAsync();
            foreach (var menuCat in menuCategories)
            {
                if (menuCat.MenuId == id && menuCat.IsDeleted == false)
                {
                    var menuCate = menuCat;
                    foreach (var category in catetables)
                    {
                        if(menuCate.CategoryId == category.CategoryId && category.IsDeleted == false)
                        {
                            category.IsDeleted = true;
                            _context.CategoryTables.Update(category);
                            _context.SaveChanges();
                        }
                    }
                    
                    menuCat.IsDeleted = true;
                    _context.MenuCategories.Update(menuCat);
                    _context.SaveChanges();
                }
            }

           


            //.MenuTables.Remove(menuTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuTableExists(int id)
        {
            return (_context.MenuTables?.Any(e => e.MenuId == id)).GetValueOrDefault();
        }
    }
}
