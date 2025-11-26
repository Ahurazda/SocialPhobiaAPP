using System.Threading.Tasks;

namespace SocialPhobiaAPP.Pages;

public partial class MainPage : ContentPage


{


    public MainPage()
    {


        InitializeComponent();


    }





    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        if (sender is HorizontalStackLayout tappedStack)
        {
            string name = tappedStack.ClassId;
            
            await Shell.Current.GoToAsync($"///chapterPage?name={name}");

        }

    }

   private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///settingsPage");
    }
}