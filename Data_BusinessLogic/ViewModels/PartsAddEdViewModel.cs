using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_BusinessLogic.Services;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class PartsAddEdViewModel : BindableBase
    {
        private IPartsRepository _repository;
        public PartsAddEdViewModel(IPartsRepository repo)
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

        private RepairParts _editingRepairPart = null;
        private ValidableParts _repairPart;
        public ValidableParts RepairPart
        {
            get => _repairPart;
            set => SetProperty(ref _repairPart, value);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }
        public event Action Done;

        private void OnCanExecuteChanges(object sender, EventArgs e)
        {
            SaveCommand.OnCanExecuteChanged();
        }

        private void CopyRepairPart(RepairParts source, ValidableParts target)
        {
            target.ID = source.ID;
            if (IsEditMode)
            {
                target.Name = source.Name;
                target.Price = source.Price;
            }
        }

        internal void SetRepairPart(RepairParts repairPart)
        {
            _editingRepairPart = repairPart;
            if (RepairPart != null)
                RepairPart.ErrorsChanged -= OnCanExecuteChanges;
            RepairPart = new ValidableParts();
            RepairPart.ErrorsChanged += OnCanExecuteChanges;
            CopyRepairPart(repairPart, RepairPart);
        }

        internal void OnCancel()
        {
            Done?.Invoke();
        }

        private bool CanSave() => !RepairPart.HasErrors;

        private void UpdateRepairPart(ValidableParts source, RepairParts target)
        {
            target.Name = source.Name;
            target.Price = source.Price;
        }

        private async void OnSave()
        {
            UpdateRepairPart(RepairPart, _editingRepairPart);
            if (IsEditMode)
                await _repository.UpdatePartAsync(_editingRepairPart);
            else
                await _repository.AddPartAsync(_editingRepairPart);
            Done?.Invoke();
        }
    }
}
