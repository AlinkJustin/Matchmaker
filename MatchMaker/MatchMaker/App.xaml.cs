using MatchMaker.Abstract;
using MatchMaker.Concrete;
using Nancy.TinyIoc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatchMaker
{
    public partial class App : Application
    {
        private static TinyIoCContainer _container = TinyIoCContainer.Current;

        public App()
        {
            InitializeComponent();

            _container.Register<IASCIICalculator, ASCIICalculator>();
            _container.Register<IComplexCalculator, ComplexCalculator>();

            MainPage = new NavigationPage(new MainPage(_container.Resolve<IASCIICalculator>(), _container.Resolve<IComplexCalculator>()));            
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
