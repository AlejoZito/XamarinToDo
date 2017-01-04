using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinToDo.View
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(ContentPage contentPage)
        {
            BackgroundColor = Color.FromHex("#ef1501");
            Title = "Aplicación Test";
            BindingContext = contentPage;
        }
    }
}
