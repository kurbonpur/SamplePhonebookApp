namespace SamplePhonebookApp.Models.Actions
{
    public class SortViewModel
    {
        public SortState IdSort { get; private set; } // значение для сортировки по ID
        public SortState NameSort { get; private set; } // значение для сортировки по имени        
        public SortState TelephoneSort { get; private set; } // значение для сортировки по номер телефона  
        public SortState AdressSort { get; private set; } // значение для сортировки по адресс        
        public SortState CategorySort { get; private set; }   // значение для сортировки по компании
        public SortState Current { get; private set; }     // текущее значение сортировки

        public SortViewModel(SortState sortOrder)
        {
            IdSort = sortOrder == SortState.IDAsc ? SortState.IdDesc : SortState.IDAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            TelephoneSort = sortOrder == SortState.TelephoneAsc ? SortState.TelephoneDesc : SortState.TelephoneAsc;
            AdressSort = sortOrder == SortState.AddressAsc ? SortState.AddressDesc : SortState.AddressAsc;
            CategorySort = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;
            Current = sortOrder;
        }
    }
}