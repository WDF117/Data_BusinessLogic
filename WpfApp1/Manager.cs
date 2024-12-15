using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1;
using WpfApp1.Services;
using WpfApp1.UserControl;
using WpfApp1.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Unity;


namespace WpfApp1
{
    internal class Manager
    {
        :BindableBase
    {
        private AddEditRequestViewModel _addEditRequestViewModel;
        private AddEditUserViewModel _addEditUserViewModel;
        private CommentAdEdViewModel _commentAdEdViewModel;
        private CommentViewModel _commentViewModel;
        private HomeTechModelViewModel _homeTechViewModel;
        private HomeTechTypeViewModel _homeTechTypeViewModel;
        private HTMAddEdViewModel _htmaEdViewModel;
        private HTTAddEdViewModel _httaEdViewModel;
        private LoginViewModel _loginViewModel;
        private PartsAddEdViewModel _partsAddEdViewModel;
        private PartsListViewModel _partsListViewModel;
        private RequestListViewModel _requestListViewModel;
        private UserListViewModel _userListViewModel;

        public Manager()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigation);

            _requestListViewModel = RepoContainer.Container.Resolve<RequestListViewModel>();
            _addEditRequestViewModel = RepoContainer.Container.Resolve<AddEditRequestViewModel>();
            _userListViewModel = RepoContainer.Container.Resolve<UserListViewModel>();
            _addEditUserViewModel = RepoContainer.Container.Resolve<AddEditUserViewModel>();
            _commentViewModel = RepoContainer.Container.Resolve<CommentViewModel>();
            _commentAdEdViewModel = RepoContainer.Container.Resolve<CommentAdEdViewModel>();
            _homeTechViewModel = RepoContainer.Container.Resolve<HomeTechModelViewModel>();
            _homeTechTypeViewModel = RepoContainer.Container.Resolve<HomeTechTypeViewModel>();
            _partsAddEdViewModel = RepoContainer.Container.Resolve<PartsAddEdViewModel>();
            _partsListViewModel = RepoContainer.Container.Resolve<PartsListViewModel>();

            _requestListViewModel.AddRequestRequested += NavigateToAddRequest;
            _requestListViewModel.EditRequestRequested += NavigateToEditRequest;
            _userListViewModel.AddUserRequested += NavigateToAddUser;
            _userListViewModel.EditUserRequested += NavigateToEditUser;
            _commentViewModel.AddCommentRequested += NavigateToAddComment;
            _commentViewModel.EditCommentRequested += NavigateToEditComment;
            _homeTechViewModel.AddHomeTechModelRequested += NavigateToAddHomeTechModel;
            _homeTechViewModel.EditHomeTechModelRequested += NavigateToEditHomeTechModel;
            _homeTechTypeViewModel.AddHomeTechTypeRequested += NavigateToAddHomeTechType;
            _homeTechTypeViewModel.EditHomeTechTypeRequested += NavigateToEditHomeTechType;
            _partsListViewModel.AddPartRequested += NavigateToAddPart;
            _partsListViewModel.EditPartRequested += NavigateToEditPart;
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
                case "requests":
                    CurrentViewModel = _requestListViewModel;
                    break;
                case "users":
                    CurrentViewModel = _userListViewModel;
                    break;
                case "comments":
                    CurrentViewModel = _commentViewModel;
                    break;
                case "homeTechModels":
                    CurrentViewModel = _homeTechViewModel;
                    break;
                case "homeTechTypes":
                    CurrentViewModel = _homeTechTypeViewModel;
                    break;
                case "parts":
                    CurrentViewModel = _partsListViewModel;
                    break;
                default:
                    CurrentViewModel = _loginViewModel;
                    break;
            }
        }
        private void NavigateToAddRequest()
        {
            _addEditRequestViewModel.IsEditMode = false;
            _addEditRequestViewModel.SetRequest(new Requests());
            CurrentViewModel = _addEditRequestViewModel;
        }

        private void NavigateToEditRequest(Requests request)
        {
            _addEditRequestViewModel.IsEditMode = true;
            _addEditRequestViewModel.SetRequest(request);
            CurrentViewModel = _addEditRequestViewModel;
        }

        private void NavigateToAddUser()
        {
            _addEditUserViewModel.IsEditMode = false;
            _addEditUserViewModel.SetUser(new Users());
            CurrentViewModel = _addEditUserViewModel;
        }

        private void NavigateToEditUser(Users user)
        {
            _addEditUserViewModel.IsEditMode = true;
            _addEditUserViewModel.SetUser(user);
            CurrentViewModel = _addEditUserViewModel;
        }
        private void NavigateToAddComment()
        {
            _commentAdEdViewModel.IsEditMode = false;
            _commentAdEdViewModel.SetComment(new Comments());
            CurrentViewModel = _commentAdEdViewModel;
        }

        private void NavigateToEditComment(Comments comment)
        {
            _commentAdEdViewModel.IsEditMode = true;
            _commentAdEdViewModel.SetComment(comment);
            CurrentViewModel = _commentAdEdViewModel;
        }
        private void NavigateToAddHomeTechModel()
        {
            _htmaEdViewModel.IsEditMode = false;
            _htmaEdViewModel.SetHomeTechModel(new HomeTechModel());
            CurrentViewModel = _htmaEdViewModel;
        }

        private void NavigateToEditHomeTechModel(HomeTechModel homeTechModel)
        {
            _htmaEdViewModel.IsEditMode = true;
            _htmaEdViewModel.SetHomeTechModel(homeTechModel);
            CurrentViewModel = _htmaEdViewModel;
        }
        private void NavigateToAddHomeTechType()
        {
            _httaEdViewModel.IsEditMode = false;
            _httaEdViewModel.SetHomeTechType(new HomeTechType());
            CurrentViewModel = _httaEdViewModel;
        }

        private void NavigateToEditHomeTechType(HomeTechType homeTechType)
        {
            _httaEdViewModel.IsEditMode = true;
            _httaEdViewModel.SetHomeTechType(homeTechType);
            CurrentViewModel = _httaEdViewModel;
        }
        private void NavigateToAddPart()
        {
            _partsAddEdViewModel.IsEditMode = false;
            _partsAddEdViewModel.SetRepairPart(new RepairParts());
            CurrentViewModel = _partsAddEdViewModel;
        }

        private void NavigateToEditPart(RepairParts part)
        {
            _partsAddEdViewModel.IsEditMode = true;
            _partsAddEdViewModel.SetRepairPart(part);
            CurrentViewModel = _partsAddEdViewModel;
        }
    }
}
}
