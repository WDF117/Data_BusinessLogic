using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Data_BusinessLogic.DB
{
    public class User : Interface.IUser, INotifyPropertyChanged
    {
        private int id;
        private string login;
        private string password;
        private long phone;

        [JsonPropertyName("id")]
        public int Id
        {
            get => id;
            private set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        [JsonPropertyName("login")]
        [Required]
        [MaxLength(125)]
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        [JsonIgnore]
        [Required]
        [MaxLength(50)]
        public string Password 
        { 
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        [JsonPropertyName("phone")]
        [Required]
        public long Phone { get => phone; set => phone = value; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Surname { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // Бизнес-логика
        public bool ValidatePassword(string password)
        {
            return password == Password;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
