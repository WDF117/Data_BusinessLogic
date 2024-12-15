using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class ValidableUser : ValidableBindableBase
    {
        private int _id;
        public int ID { get => _id; set => SetProperty(ref _id, value); }

        private string _login;
        [Required]
        public string Login { get => _login; set => SetProperty(ref _login, value); }

        private string _password;
        [Required]
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        private long? _phone;
        [Phone]
        public long? Phone { get => _phone; set => SetProperty(ref _phone, value); }

        private string _name;
        [Required]
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _sName;
        public string S_Name { get => _sName; set => SetProperty(ref _sName, value); }

        private string _lName;
        public string L_Name { get => _lName; set => SetProperty(ref _lName, value); }

        private int? _userType;
        public int? UserType { get => _userType; set => SetProperty(ref _userType, value); }
    }
}
