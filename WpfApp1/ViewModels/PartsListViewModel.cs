using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Services;

namespace WpfApp1.ViewModels
{
    public class PartsListViewModel : BindableBase
    {
        private readonly IPartsRepository _repository;
        private ObservableCollection<RepairParts>? _repairParts;
        public ObservableCollection<RepairParts>? RepairParts
        {
            get => _repairParts;
            set => SetProperty(ref _repairParts, value);
        }
        private RepairParts? _selectedRepairPart;
        public RepairParts? SelectedRepairPart
        {
            get => _selectedRepairPart;
            set => SetProperty(ref _selectedRepairPart, value);
        }
        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterRepairParts(_searchInput);
            }
        }
        private List<RepairParts>? _repairPartsList;
        public RelayCommand AddRepairPartCommand { get; private set; }
        public RelayCommand<RepairParts> EditPartCommand { get; private set; }
        public RelayCommand<RepairParts> DeletePartCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }
        public event Action AddPartRequested = delegate { };
        public event Action<RepairParts> EditPartRequested = delegate { };
        public PartsListViewModel(IPartsRepository repository)
        {
            _repository = repository;
            RepairParts = new ObservableCollection<RepairParts>();
            LoadRepairParts();
            AddRepairPartCommand = new RelayCommand(OnAddRepairPart);
            EditPartCommand = new RelayCommand<RepairParts>(OnEditRepairPart);
            DeletePartCommand = new RelayCommand<RepairParts>(OnDeleteRepairPart);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }
        public async void LoadRepairParts()
        {
            _repairPartsList = await _repository.GetAllPartsAsync();
            RepairParts = new ObservableCollection<RepairParts>(_repairPartsList);
        }
        private void FilterRepairParts(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                RepairParts = new ObservableCollection<RepairParts>(_repairPartsList);
            }
            else
            {
                RepairParts = new ObservableCollection<RepairParts>(
                    _repairPartsList.Where(r => r.Name.ToLower().Contains(searchText.ToLower()) ||
                                                 r.Price.ToString().Contains(searchText)));
            }
        }
        private void OnAddRepairPart()
        {
            AddPartRequested.Invoke();
        }
        private void OnEditRepairPart(RepairParts repairPart)
        {
            EditPartRequested.Invoke(repairPart);
        }
        private async void OnDeleteRepairPart(RepairParts repairPart)
        {
            await _repository.DeletePartAsync(repairPart.ID);
            LoadRepairParts(); 
        }
        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
