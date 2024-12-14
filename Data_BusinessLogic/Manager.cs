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
using Microsoft.IdentityModel.Tokens;
using Unity;

namespace Data_BusinessLogic
{
    public class Manager :BindableBase
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
                    throw new ArgumentException("Unknown navigation destination", nameof(dest));
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
            _partsAddEdViewModel.SetPart(new Parts());
            CurrentViewModel = _partsAddEdViewModel;
        }

        private void NavigateToEditPart(Parts part)
        {
            _partsAddEdViewModel.IsEditMode = true;
            _partsAddEdViewModel.SetPart(part);
            CurrentViewModel = _partsAddEdViewModel;
        }
    }
}
}
