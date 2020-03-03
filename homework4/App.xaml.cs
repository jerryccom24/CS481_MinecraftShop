using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace homework4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());//Make the root page (Main Page) a Nav page
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
