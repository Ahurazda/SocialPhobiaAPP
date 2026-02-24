using SocialPhobiaAPP.Services;
using SocialPhobiaAPP.ViewModels;
using System.Threading.Tasks;

namespace SocialPhobiaAPP.Pages;

public partial class SettingsPage : ContentPage
{
	private DatabaseService _databaseService;
    public SettingsPage()
	{
		InitializeComponent();
		_databaseService = new DatabaseService();
    }

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///MainPage");
	}

     void DarkThemeToggled(object sender, ToggledEventArgs e)
	{
		
        if (e.Value)
		{
			App.Current.UserAppTheme = AppTheme.Dark;
		}
		else
		{
			App.Current.UserAppTheme = AppTheme.Light;
		}
    }

		
}