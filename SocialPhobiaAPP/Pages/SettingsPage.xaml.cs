using System.Threading.Tasks;

namespace SocialPhobiaAPP.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///MainPage");
	}
}