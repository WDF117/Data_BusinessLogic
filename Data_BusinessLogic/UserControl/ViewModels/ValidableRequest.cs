using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class ValidableRequest : ValidableBindableBase
    {
        private int _id;
        public int ID { get => _id; set => SetProperty(ref _id, value); }

        private DateTime? _startDate;
        [Required]
        public DateTime? StartDate { get => _startDate; set => SetProperty(ref _startDate, value); }

        private string _problemDescription;
        [Required]
        public string ProblemDescription { get => _problemDescription; set => SetProperty(ref _problemDescription, value); }

        private DateTime? _completionDate;
        public DateTime? CompletionDate { get => _completionDate; set => SetProperty(ref _completionDate, value); }

        private int? _homeTechType;
        public int? HomeTechType { get => _homeTechType; set => SetProperty(ref _homeTechType, value); }

        private int? _homeTechModel;
        public int? HomeTechModel { get => _homeTechModel; set => SetProperty(ref _homeTechModel, value); }

        private int? _repairParts;
        public int? RepairParts { get => _repairParts; set => SetProperty(ref _repairParts, value); }

        private int? _clientID;
        public int? ClientID { get => _clientID; set => SetProperty(ref _clientID, value); }

        private int? _masterID;
        public int? MasterID { get => _masterID; set => SetProperty(ref _masterID, value); }

        private int? _status;
        public int? Status { get => _status; set => SetProperty(ref _status, value); }
    }
}
