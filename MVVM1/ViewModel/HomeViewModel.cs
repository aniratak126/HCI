using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        private string homeViewStartMessage = "hello";

        public string HomeViewStartMessage { get => homeViewStartMessage;}
    }
}
