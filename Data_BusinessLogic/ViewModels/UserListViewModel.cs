using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class UserListViewModel : BindableBase
    {
        private readonly IUserRepository _repository;

        public UserListViewModel(IUserRepository repository)
        {
            _repository = repository;
            Users = new ObservableCollection<Users>();
            LoadUsers();

            AddUserCommand = new RelayCommand(OnAddUser);
            EditUserCommand = new RelayCommand<Users>(OnEditUser);
            ClearSearchInputCommand = new RelayCommand(OnClearSearch);
        }

        private ObservableCollection<Users>? _users;
        public ObservableCollection<Users>? Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private List<Users>? _usersList;
        public async void LoadUsers()
        {
            _usersList = await _repository.GetAllUsersAsync();
            Users = new ObservableCollection<Users>(_usersList);
        }

        private string? _searchInput;
        public string? SearchInput
        {
            get => _searchInput;
            set
            {
                SetProperty(ref _searchInput, value);
                FilterUsersByName(_searchInput);
            }
        }

        private void FilterUsersByName(string? searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                Users = new ObservableCollection<Users>(_usersList);
            }
            else
            {
                Users = new ObservableCollection<Users>(
                    _usersList.Where(u => u.Name.ToLower().Contains(searchText.ToLower()) ||
                                          u.S_Name.ToLower().Contains(searchText.ToLower()) ||
                                          u.L_Name.ToLower().Contains(searchText.ToLower())));
            }
        }

        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand<Users> EditUserCommand { get; private set; }
        public RelayCommand ClearSearchInputCommand { get; private set; }

        public event Action AddUserRequested = delegate { };
        public event Action<Users> EditUserRequested = delegate { };

        private void OnAddUser()
        {
            AddUserRequested.Invoke();
        }

        private void OnEditUser(Users user)
        {
            EditUserRequested.Invoke(user);
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }
    }
}
