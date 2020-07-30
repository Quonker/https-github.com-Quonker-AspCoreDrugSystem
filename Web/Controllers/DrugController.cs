using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class DrugController : Controller
    {
        DrugContext db;

        public DrugController(DrugContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.TradenameAsc)
        {
            IQueryable<Drug> drugs = db.Drugs.Include(x => x.Company);

            ViewData["TradenameSort"] = sortOrder == SortState.TradenameAsc ? SortState.TradenameDesc : SortState.TradenameAsc;
            ViewData["PriceSort"] = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            drugs = sortOrder switch
            {
                SortState.TradenameDesc => drugs.OrderByDescending(s => s.Tradename),
                SortState.PriceAsc => drugs.OrderBy(s => s.Price),
                SortState.PriceDesc => drugs.OrderByDescending(s => s.Price),
                SortState.CompanyAsc => drugs.OrderBy(s => s.Company.Name),
                SortState.CompanyDesc => drugs.OrderByDescending(s => s.Company.Name),
                _ => drugs.OrderBy(s => s.Tradename),
            };
            return View(await drugs.AsNoTracking().ToListAsync());
        }

        //[Authorize(Roles = "administrator")]
        public IActionResult Create()
        {
            SelectList companies = new SelectList(db.Companies, "Id", "Name");
            ViewBag.Companies = companies;
            return View();
        }
       // [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(Drug drug)
        {
            if(db.Drugs.FirstOrDefaultAsync(d => d.Tradename == drug.Tradename) == null)
            {
                db.Drugs.Add(drug);
                await db.SaveChangesAsync();
               
            }
            else
            {

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Drug user = await db.Drugs.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
    }
}
