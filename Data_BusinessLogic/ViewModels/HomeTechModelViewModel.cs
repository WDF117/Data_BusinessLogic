using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class HomeTechModelViewModel : BindableBase
    {
        private ObservableCollection<HomeTechModel>? _homeTechModels;
        public ObservableCollection<HomeTechModel>? HomeTechModels
        {
            get => _homeTechModels;
            set => SetProperty(ref _homeTechModels, value);
        }
        private HomeTechModel? _selectedHomeTechModel;
        public HomeTechModel? SelectedHomeTechModel
        {
            get => _selectedHomeTechModel;
            set => SetProperty(ref _selectedHomeTechModel, value);
        }

        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterHomeTechModels(_searchInput);
            }
        }
        private List<HomeTechModel>? _homeTechModelsList;

        public RelayCommand AddHomeTechModelCommand { get; private set; }

        public RelayCommand<HomeTechModel> EditHomeTechModelCommand { get; private set; }

        public RelayCommand ClearSearchInputCommand { get; private set; }

        public event Action AddHomeTechModelRequested = delegate { };

        public event Action<HomeTechModel> EditHomeTechModelRequested = delegate { };

        private readonly IHomeTechModelRepository _repository;

        public HomeTechModelViewModel(IHomeTechModelRepository repository)
        {
            _repository = repository;
            HomeTechModels = new ObservableCollection<HomeTechModel>();
            LoadHomeTechModels();

            AddHomeTechModelCommand = new RelayCommand(OnAddHomeTechModel);
            EditHomeTechModelCommand = new RelayCommand<HomeTechModel>(OnEditHomeTechModel);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }

        public async void LoadHomeTechModels()
        {
            _homeTechModelsList = await _repository.GetAllHomeTechModelsAsync();
            HomeTechModels = new ObservableCollection<HomeTechModel>(_homeTechModelsList);
        }

        private void FilterHomeTechModels(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                HomeTechModels = new ObservableCollection<HomeTechModel>(_homeTechModelsList);
            }
            else
            {
                HomeTechModels = new ObservableCollection<HomeTechModel>(
                    _homeTechModelsList.Where(h => h.Name.ToLower().Contains(searchText.ToLower())));
            }
        }

        private void OnAddHomeTechModel()
        {
            AddHomeTechModelRequested.Invoke();
        }

        private void OnEditHomeTechModel(HomeTechModel homeTechModel)
        {
            EditHomeTechModelRequested.Invoke(homeTechModel);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
