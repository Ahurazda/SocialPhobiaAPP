namespace SocialPhobiaAPP.Pages;

public partial class TechniquesPage : ContentPage
{
	public TechniquesPage()
	{
		InitializeComponent();
	}

	private async void OnImageTapped(object sender, EventArgs e)
	{
        
        await Shell.Current.GoToAsync("//breathingPage");
    }

	private async void OnImageTapped1(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//meditationPage");
	}

	private async void OnImageTapped2(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//expositionsPage");
    }
}