using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    public class ValidableParts : ValidableBindableBase
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        [Required]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int? _price;
        public int? Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }
    }
}
