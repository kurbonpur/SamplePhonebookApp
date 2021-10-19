using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using SamplePhonebookApp.Models;
using SamplePhonebookApp.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly ApplicationContext _context;
        private readonly ILogger _logger;

        public ActionRepository(ApplicationContext context)
        {
            _context = context;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task<IndexViewModel> Index(int category, string name, int page = 1,
             SortState sortOrder = SortState.NameAsc)
        {
            if (name == "0")
                name = "";
            int pageSize = 3;

            //фильтрация
            IQueryable<Phone> phones = _context.Phones.Include(x => x.Category);
            if (category != 0)
            {
                phones = phones.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                phones = phones.Where(p => p.Name.Contains(name));
            }

            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    phones = phones.OrderByDescending(s => s.Name);
                    break;
                case SortState.IDAsc:
                    phones = phones.OrderBy(s => s.Id);
                    break;
                case SortState.IdDesc:
                    phones = phones.OrderByDescending(s => s.Id);
                    break;
                case SortState.AddressAsc:
                    phones = phones.OrderBy(s => s.Address);
                    break;
                case SortState.AddressDesc:
                    phones = phones.OrderByDescending(s => s.Address);
                    break;
                case SortState.CategoryAsc:
                    phones = phones.OrderBy(s => s.Category.Name);
                    break;
                case SortState.CategoryDesc:
                    phones = phones.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    phones = phones.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await phones.CountAsync();
            var items = await phones.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.Categories.ToList(), category, name),
                Phones = items,

            };
            return viewModel;
        }
    }
}
