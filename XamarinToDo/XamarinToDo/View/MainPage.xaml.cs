using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinToDo.View;
using Xamarin.Forms;

namespace XamarinToDo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            HomeBtn.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new MainPage());
            };
            ToDoBtn.Clicked += (o, e) =>
            {
                Navigation.PushAsync(new ToDoPage());
            };
        }
    }
}
