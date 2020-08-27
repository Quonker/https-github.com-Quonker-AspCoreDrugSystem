using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class DrugController : Controller
    {
        DrugContext db;
        private readonly IMapper _mapper;
        IWebHostEnvironment _appEnvironment;

        public DrugController(DrugContext db, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            this.db = db;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
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
            var items =  _mapper.Map<IEnumerable<DrugViewModel>>(await drugs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync());

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_mapper.Map<IEnumerable<CompanyViewModel>>(db.Companies).ToList(), company, name),
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
        public async Task<IActionResult> Create(DrugViewModel drugView, IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files
                string path = "/Files/" + file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                Drug drug = _mapper.Map<DrugViewModel, Drug>(drugView);
                drug.Path = path;
                db.Drugs.Add(drug);
                await db.SaveChangesAsync();
            }
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
                    DrugViewModel drugView = _mapper.Map<Drug, DrugViewModel>(drug);
                    return View(drugView);
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
                    DrugViewModel drugView = _mapper.Map<Drug, DrugViewModel>(drug);
                    return View(drugView);
                }
                    
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DrugViewModel drugView, IFormFile file)
        {
            if (file != null)
            {
                // путь к папке Files
                string path = "/Files/" + file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                Drug drug = _mapper.Map<DrugViewModel, Drug>(drugView);
                drug.Path = path;
                db.Drugs.Update(drug);
                await db.SaveChangesAsync();
            }
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
                {
                    drug.Company = await db.Companies.FirstOrDefaultAsync(c => c.Id == drug.CompanyId);
                    DrugViewModel drugView = _mapper.Map<Drug, DrugViewModel>(drug);
                    return View(drugView);
                }    
                    
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
