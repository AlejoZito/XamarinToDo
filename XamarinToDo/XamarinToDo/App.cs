using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinToDo.View;
using Xamarin.Forms;

namespace XamarinToDo
{
    public class App : Application
    {
        public App()
        {

            //MainPage en XAML
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new ToDoPage();

            //MainPage en código c#
            //MainPage = new MainContentPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        
    }
}
