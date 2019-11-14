using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.ViewModel
{
    public class FighterOptionsViewModel : ViewModelBase
    {
        private bool _selected;
        public bool Selected {
            get { return _selected; }
            set
            {
                _selected = value;
                RaisePropertyChanged("Selected");
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public FighterOptionsViewModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
