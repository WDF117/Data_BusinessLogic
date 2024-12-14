using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_BusinessLogic.UserControl.ViewModels
{
    public class ValidableHomeTechModel :   ValidableBindableBase
    {
        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name;
        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public virtual ICollection<Requests> Requests { get; set; }

        public ValidableHomeTechModel()
        {
            Requests = new HashSet<Requests>();
        }
    }
}
