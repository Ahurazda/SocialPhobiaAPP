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
      
        var currentTheme = Application.Current?.RequestedTheme;

        if (currentTheme == AppTheme.Dark)
        {
            themeSwitch.IsToggled = true;
        }
        else
        {
            themeSwitch.IsToggled = false;
        }
    }
	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("///MainPage");
	}

     void DarkThemeToggled(object sender, ToggledEventArgs e)
	{
        var app = Application.Current;
        if (app == null)
            return;

        app.UserAppTheme = app.UserAppTheme switch
        {
            AppTheme.Light => AppTheme.Dark,
            AppTheme.Dark => AppTheme.Light,
            _ => AppTheme.Dark,
        };
    }

		
}