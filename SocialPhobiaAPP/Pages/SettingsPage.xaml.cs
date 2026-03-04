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

        Application.Current.UserAppTheme = Application.Current.UserAppTheme switch
        {
            AppTheme.Light => AppTheme.Dark,
            AppTheme.Dark => AppTheme.Light,
            _ => AppTheme.Dark,
            
        };

    }

		
}