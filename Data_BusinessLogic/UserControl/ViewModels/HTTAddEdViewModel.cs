using Data_BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class HTTAddEdViewModel : BindableBase
    {
        private readonly IHomeTechTypeRepository _repository;

        public HTTAddEdViewModel(IHomeTechTypeRepository repository)
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

        private HomeTechType _editingHomeTechType = null;
        private ValidableHomeTechType _homeTechType;
        public ValidableHomeTechType HomeTechType
        {
            get => _homeTechType;
            set => SetProperty(ref _homeTechType, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyHomeTechType(HomeTechType source, ValidableHomeTechType target)
        {
            target.ID = source.ID;
            if (IsEditMode)
            {
                target.Name = source.Name;
            }
        }

        internal void SetHomeTechType(HomeTechType homeTechType)
        {
            _editingHomeTechType = homeTechType;
            if (HomeTechType != null)
                HomeTechType.ErrorsChanged -= OnCanExecuteChanges;
            HomeTechType = new ValidableHomeTechType();
            HomeTechType.ErrorsChanged += OnCanExecuteChanges;
            CopyHomeTechType(homeTechType, HomeTechType);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !HomeTechType.HasErrors;

        private void UpdateHomeTechType(ValidableHomeTechType source, HomeTechType target)
        {
            target.Name = source.Name;
        }

        private async void OnSave()
        {
            UpdateHomeTechType(HomeTechType, _editingHomeTechType);
            if (IsEditMode)
                await _repository.UpdateHomeTechTypeAsync(_editingHomeTechType);
            else
                await _repository.AddHomeTechTypeAsync(_editingHomeTechType);
            Done?.Invoke();
        }
    }
}
