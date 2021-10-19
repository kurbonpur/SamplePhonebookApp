using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SamplePhonebookApp.Models.Actions
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories, int? category, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            categories.Insert(0, new Category { Name = "Все", Id = 0 });
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
            SelectedName = name;
        }
        public SelectList Categories { get; private set; } // список Категорий
        public int? SelectedCategory { get; private set; }   // выбранная категория
        public string SelectedName { get; private set; }    // введенное имя
    }
}