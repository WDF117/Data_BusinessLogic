using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class HomeTechTypeViewModel : BindableBase
    {
        private ObservableCollection<HomeTechType>? _homeTechTypes;
        public ObservableCollection<HomeTechType>? HomeTechTypes
        {
            get => _homeTechTypes;
            set => SetProperty(ref _homeTechTypes, value);
        }
        private HomeTechType? _selectedHomeTechType;
        public HomeTechType? SelectedHomeTechType
        {
            get => _selectedHomeTechType;
            set => SetProperty(ref _selectedHomeTechType, value);
        }
        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterHomeTechTypes(_searchInput);
            }
        }
        private List<HomeTechType>? _homeTechTypesList;
        public RelayCommand AddHomeTechTypeCommand { get; private set; }
        public RelayCommand<HomeTechType> EditHomeTechTypeCommand { get; private set; }
        public RelayCommand<HomeTechType> DeleteHomeTechTypeCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }
        public event Action AddHomeTechTypeRequested = delegate { };
        public event Action<HomeTechType> EditHomeTechTypeRequested = delegate { };

        private readonly IHomeTechTypeRepository _repository;

        public HomeTechTypeViewModel(IHomeTechTypeRepository repository)
        {
            _repository = repository;
            HomeTechTypes = new ObservableCollection<HomeTechType>();
            LoadHomeTechTypes();
            AddHomeTechTypeCommand = new RelayCommand(OnAddHomeTechType);
            EditHomeTechTypeCommand = new RelayCommand<HomeTechType>(OnEditHomeTechType);
            DeleteHomeTechTypeCommand = new RelayCommand<HomeTechType>(OnDeleteHomeTechType);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }
        public async void LoadHomeTechTypes()
        {
            _homeTechTypesList = await _repository.GetAllHomeTechTypesAsync();
            HomeTechTypes = new ObservableCollection<HomeTechType>(_homeTechTypesList);
        }
        private void FilterHomeTechTypes(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                HomeTechTypes = new ObservableCollection<HomeTechType>(_homeTechTypesList);
            }
            else
            {
                HomeTechTypes = new ObservableCollection<HomeTechType>(
                    _homeTechTypesList.Where(h => h.Name.ToLower().Contains(searchText.ToLower())));
            }
        }
        private void OnAddHomeTechType()
        {
            AddHomeTechTypeRequested.Invoke();
        }
        private void OnEditHomeTechType(HomeTechType homeTechType)
        {
            EditHomeTechTypeRequested.Invoke(homeTechType);
        }
        private async void OnDeleteHomeTechType(HomeTechType homeTechType)
        {
            await _repository.DeleteHomeTechTypeAsync(homeTechType.ID);
            LoadHomeTechTypes();  
        }
        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
