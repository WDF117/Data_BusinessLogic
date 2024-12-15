using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class ValidableComment : ValidableBindableBase
    {
        private int _id;
        public int ID { get => _id; set => SetProperty(ref _id, value); }

        private string _message;
        [Required(ErrorMessage = "Message is required.")]
        public string message { get => _message; set => SetProperty(ref _message, value); }

        private int? _requestID;
        public int? requestID { get => _requestID; set => SetProperty(ref _requestID, value); }

        private int? _masterID;
        public int? masterID { get => _masterID; set => SetProperty(ref _masterID, value); }
    }
}
