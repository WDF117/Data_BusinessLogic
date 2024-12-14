using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class HTMAddEdViewModel : BindableBase
    {
        private readonly IHomeTechModelRepository _repository;

        public HTMAddEdViewModel(IHomeTechModelRepository repository)
        {
            _repository = repository;
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set => SetProperty(ref _isEditMode, value);
        }

        private HomeTechModel _editingHomeTechModel = null;
        private ValidableHomeTechModel _homeTechModel;
        public ValidableHomeTechModel HomeTechModel
        {
            get => _homeTechModel;
            set => SetProperty(ref _homeTechModel, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyHomeTechModel(HomeTechModel source, ValidableHomeTechModel target)
        {
            target.ID = source.ID;
            if (IsEditMode)
            {
                target.Name = source.Name;
            }
        }

        internal void SetHomeTechModel(HomeTechModel homeTechModel)
        {
            _editingHomeTechModel = homeTechModel;
            if (HomeTechModel != null)
                HomeTechModel.ErrorsChanged -= OnCanExecuteChanges;
            HomeTechModel = new ValidableHomeTechModel();
            HomeTechModel.ErrorsChanged += OnCanExecuteChanges;
            CopyHomeTechModel(homeTechModel, HomeTechModel);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !HomeTechModel.HasErrors;

        private void UpdateHomeTechModel(ValidableHomeTechModel source, HomeTechModel target)
        {
            target.Name = source.Name;
        }

        private async void OnSave()
        {
            UpdateHomeTechModel(HomeTechModel, _editingHomeTechModel);
            if (IsEditMode)
                await _repository.UpdateHomeTechModelAsync(_editingHomeTechModel);
            else
                await _repository.AddHomeTechModelAsync(_editingHomeTechModel);
            Done?.Invoke();
        }
    }
}
