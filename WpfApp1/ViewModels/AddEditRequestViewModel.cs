using WpfApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class AddEditRequestViewModel : BindableBase
    {
        private IRequestRepository _repository;
        public AddEditRequestViewModel(IRequestRepository repo)
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

        private Requests _editingRequest = null;
        private ValidableRequest _request;
        public ValidableRequest Request
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyRequest(Requests source, ValidableRequest target)
        {
            target.ID = source.ID;
            if (IsEditMode)
            {
                target.StartDate = source.startDate;
                target.ProblemDescription = source.problemDescryption;
                target.CompletionDate = source.completionDate;
                target.HomeTechType = source.homeTechType;
                target.HomeTechModel = source.homeTechModel;
                target.RepairParts = source.repairParts;
                target.ClientID = source.clientID;
                target.MasterID = source.masterID;
                target.Status = source.status;
            }
        }

        internal void SetRequest(Requests request)
        {
            _editingRequest = request;
            if (Request != null)
                Request.ErrorsChanged -= OnCanExecuteChanges;
            Request = new ValidableRequest();
            Request.ErrorsChanged += OnCanExecuteChanges;
            CopyRequest(request, Request);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !Request.HasErrors;

        private void UpdateRequest(ValidableRequest source, Requests target)
        {
            target.startDate = source.StartDate;
            target.problemDescryption = source.ProblemDescription;
            target.completionDate = source.CompletionDate;
            target.homeTechType = source.HomeTechType;
            target.homeTechModel = source.HomeTechModel;
            target.repairParts = source.RepairParts;
            target.clientID = source.ClientID;
            target.masterID = source.MasterID;
            target.status = source.Status;
        }

        private async void OnSave()
        {
            UpdateRequest(Request, _editingRequest);
            if (IsEditMode)
                await _repository.UpdateRequestAsync(_editingRequest);
            else
                await _repository.AddRequestsAsync(_editingRequest);
            Done?.Invoke();
        }
    }
}
