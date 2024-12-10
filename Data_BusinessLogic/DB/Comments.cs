using Data_BusinessLogic.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data_BusinessLogic.DB
{
    public class Comments : BindableBase, IComments
    {
        private string _message;
        private int _requestId;
        private int _masterId;
        public Guid Id { get; private set; }
        [Required]
        [JsonPropertyName("message")]
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        [Required]
        [JsonPropertyName("requestId")]
        public int RequestId
        {
            get => _requestId;
            set
            {
                _requestId = value;
                OnPropertyChanged(nameof(RequestId));
            }
        }
        [Required]
        [JsonPropertyName("masterId")]
        public int MasterId
        {
            get => _masterId;
            set 
            {
                _masterId = value;
                OnPropertyChanged(nameof(MasterId)); 
            }
        }

        public Request Request { get; set; }
        public User Master { get; set; }
    }
}
