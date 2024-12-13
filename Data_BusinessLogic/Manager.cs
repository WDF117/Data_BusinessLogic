using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Data_BusinessLogic;
using Data_BusinessLogic.Services;
using Data_BusinessLogic.UserControl;
using Data_BusinessLogic.UserControl.ViewModels;

namespace Data_BusinessLogic
{
    public class Manager :BindableBase
    {
        private AddEditRequestViewModel _addEditRequestViewModel;
        private AddEditUserViewModel _addEditUser;
        private CommentAdEdViewModel _commentAdEdViewModel;
        private CommentViewModel _commentViewModel;
        private PartsAddEdViewModel _partsAddEdViewModel;
        private PartsListViewModel _partsListViewModel;
        private RequestListViewModel _requestListViewModel;
        private UserListViewModel _userListViewModel;
        
        public Manager()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigation);

        }
        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

        //открывать список клиентов
        private void OnNavigation(string dest)
        {
            switch (dest)
            {
                case "orderPrep":
                    CurrentViewModel = _orderPrepViewModel; break;
                case "customers":
                default:
                    CurrentViewModel = _customerListViewModel; break;
            }
        }

        //открывать окно для редактирования клиента
        private void NavigationToEditCustomer(Customer customer)
        {
            _addEditCustomerVewModel.IsEditeMode = true;
            _addEditCustomerVewModel.SetCustomer(customer);
            CurrentViewModel = _addEditCustomerVewModel;

        }
        private void NavigationToAddCustomer()
        {
            _addEditCustomerVewModel.IsEditeMode = false;
            _addEditCustomerVewModel.SetCustomer(new Customer
            {
                Id = Guid.NewGuid(),
            });
            CurrentViewModel = _addEditCustomerVewModel;

        }
        private void NavigateToOrder(Customer customer)
        {
            _orderViewModel.Id = customer.Id;
            CurrentViewModel = _orderViewModel;
        }
    }
}
