using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cms_wpf_app.ViewModels
{
    public partial class CreateViewModel : ObservableObject
    {

        [ObservableProperty]
        private string pageTitle = "Subit your issue";

        public CreateViewModel()
        {

        }

    }
}
