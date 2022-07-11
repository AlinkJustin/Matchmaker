using MatchMaker.Abstract;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MatchMaker
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IASCIICalculator asciiCalculator, IComplexCalculator complexCalculator)
        {
            InitializeComponent();

            _complexCalculator = complexCalculator;
            _asciiCalculator = asciiCalculator;
        }

        private IASCIICalculator _asciiCalculator;
        private IComplexCalculator _complexCalculator;

        private async void btnCalculate_OnClick(object sender, EventArgs e)
        {
            Entry name1 = (Entry)this.FindByName("Name1");
            Entry name2 = (Entry)this.FindByName("Name2");
            Label resultLabel = (Label)this.FindByName("ResultLabel");
            ProgressBar progress = (ProgressBar)this.FindByName("Progress");

            resultLabel.IsVisible = false;
            string name1Text = name1.Text;
            string name2Text = name2.Text;
            int result = 0;

            string calculatePreference = Preferences.Get("CalculatorSetting", string.Empty);
            switch (calculatePreference)
            {
                case "Chinese":                    
                    result = _complexCalculator.Calculate(name1Text, name2Text);
                    break;

                case "Default":
                    result = _asciiCalculator.Calculate(name1Text, name2Text);
                    break;

                default:
                    result = _asciiCalculator.Calculate(name1Text, name2Text);
                    break;
            }
            progress.IsVisible = true;
            progress.Progress = 0;                                 
            await progress.ProgressTo(1, 2000, Easing.Linear);
            
            resultLabel.Text = $"{result}%";
            resultLabel.IsVisible = true;
        }

        private async void btn_Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }
    }
}