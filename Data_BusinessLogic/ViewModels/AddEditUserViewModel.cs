using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.ViewModels
{
    public class AddEditUserViewModel : BindableBase
    {
        private IUserRepository _repository;

        public AddEditUserViewModel(IUserRepository repo)
        {
            _repository = repo;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private Users _editingUser = null;
        private ValidableUser _user;
        public ValidableUser User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public event Action Done;

        //----------------

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyUser(Users source, ValidableUser target)
        {
            target.ID = source.ID;
            if (IsEditMode)
            {
                target.Login = source.Login;
                target.Password = source.Password;
                target.Phone = source.Phone;
                target.Name = source.Name;
                target.S_Name = source.S_Name;
                target.L_Name = source.L_Name;
                target.UserType = source.userType;
            }
        }

        internal void SetUser(Users user)
        {
            _editingUser = user;
            if (User != null)
                User.ErrorsChanged -= OnCanExecuteChanges;
            User = new ValidableUser();
            User.ErrorsChanged += OnCanExecuteChanges;
            CopyUser(user, User);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !User.HasErrors;

        private void UpdateUser(ValidableUser source, Users target)
        {
            target.Login = source.Login;
            target.Password = source.Password;
            target.Phone = source.Phone;
            target.Name = source.Name;
            target.S_Name = source.S_Name;
            target.L_Name = source.L_Name;
            target.userType = source.UserType;
        }

        private async void OnSave()
        {
            UpdateUser(User, _editingUser);
            if (IsEditMode)
                await _repository.UpdateUsersAsync(_editingUser);
            else
                await _repository.AddUserAsync(_editingUser);
            Done?.Invoke();
        }
    }
}

