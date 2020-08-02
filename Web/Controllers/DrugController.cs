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

        public async Task<IActionResult> Index(int? company, string name, int page = 1,
             SortState sortOrder = SortState.TradenameAsc)
        {
            int pageSize = 8;

            //фильтрация
            IQueryable<Drug> drugs = db.Drugs.Include(x => x.Company);

            if (company != null && company != 0)
            {
                drugs = drugs.Where(p => p.CompanyId == company);
            }
            if (!String.IsNullOrEmpty(name))
            {
                drugs = drugs.Where(p => p.Tradename.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.TradenameDesc:
                    drugs = drugs.OrderByDescending(s => s.Tradename);
                    break;
              
                case SortState.CompanyAsc:
                    drugs = drugs.OrderBy(s => s.Company.Name);
                    break;
                case SortState.CompanyDesc:
                    drugs = drugs.OrderByDescending(s => s.Company.Name);
                    break;
                default:
                    drugs = drugs.OrderBy(s => s.Tradename);
                    break;
            }

            // пагинация
            var count = await drugs.CountAsync();
            var items = await drugs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Companies.ToList(), company, name),
                Drugs = items
            };
            return View(viewModel);
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
            db.Drugs.Add(drug);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Drug drug = await db.Drugs.FirstOrDefaultAsync(p => p.Id == id);
                if (drug != null)
                {
                    drug.Company = await db.Companies.FirstOrDefaultAsync(c => c.Id == drug.CompanyId);
                    return View(drug);
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Drug drug = await db.Drugs.FirstOrDefaultAsync(p => p.Id == id);
                if (drug != null)
                {
                    SelectList companies = new SelectList(db.Companies, "Id", "Name");
                    ViewBag.Companies = companies;
                    return View(drug);
                }
                    
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Drug drug)
        {
            db.Drugs.Update(drug);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Drug drug = await db.Drugs.FirstOrDefaultAsync(p => p.Id == id);
                if (drug != null)
                    return View(drug);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Drug drug = await db.Drugs.FirstOrDefaultAsync(p => p.Id == id);
                if (drug != null)
                {
                    db.Drugs.Remove(drug);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
