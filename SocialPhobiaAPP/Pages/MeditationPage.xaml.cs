using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;


namespace SocialPhobiaAPP.Pages;


public partial class MeditationPage : ContentPage
{
	public MeditationPage()
	{
		InitializeComponent();
	}

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		if ( mediaElement.CurrentState == MediaElementState.Playing)
		{
            mediaElement.Stop();
        }
		
        await Shell.Current.GoToAsync("//techniquesPage");
    }

}