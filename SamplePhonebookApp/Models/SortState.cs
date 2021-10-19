using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePhonebookApp.Models
{
    public enum SortState
    {
        IDAsc,    // по ID телефона по возрастанию
        IdDesc,   // по ID телефона по убыванию
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        TelephoneAsc, // по номер телефона по возрастанию
        TelephoneDesc, // по номер телефона по убыванию
        AddressAsc, // по адресу по возрастанию
        AddressDesc,    // по адресу по убыванию
        CategoryAsc, // по категории по возрастанию
        CategoryDesc // по категории по убыванию
    }
}