using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class RequestListViewModel : BindableBase
    {
        private readonly IRequestRepository _repository;

        public RequestListViewModel(IRequestRepository repository)
        {
            _repository = repository;
            Requests = new ObservableCollection<Requests>();
            LoadRequests();

            AddRequestCommand = new RelayCommand(OnAddRequest);
            EditRequestCommand = new RelayCommand<Requests>(OnEditRequest);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<Requests>? _requests;
        public ObservableCollection<Requests>? Requests
        {
            get => _requests;
            set => SetProperty(ref _requests, value);
        }

        private List<Requests>? _requestsList;
        public async void LoadRequests()
        {
            _requestsList = await _repository.GetAllRequestsAsync();
            Requests = new ObservableCollection<Requests>(_requestsList);
        }

        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterRequestsByProblemDescription(_searchInput);
            }
        }

        private void FilterRequestsByProblemDescription(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                Requests = new ObservableCollection<Requests>(_requestsList);
            }
            else
            {
                Requests = new ObservableCollection<Requests>(
                    _requestsList.Where(r => r.problemDescryption.ToLower().Contains(searchText.ToLower())));
            }
        }

        public RelayCommand AddRequestCommand { get; private set; }
        public RelayCommand<Requests> EditRequestCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }

        public event Action AddRequestRequested = delegate { };
        public event Action<Requests> EditRequestRequested = delegate { };

        private void OnAddRequest()
        {
            AddRequestRequested.Invoke();
        }

        private void OnEditRequest(Requests request)
        {
            EditRequestRequested.Invoke(request);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
