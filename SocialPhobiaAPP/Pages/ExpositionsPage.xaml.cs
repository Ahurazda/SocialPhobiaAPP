using SocialPhobiaAPP.Models;

namespace SocialPhobiaAPP.Pages;

public partial class ExpositionsPage : ContentPage
{
	List<Exposition> Expositions { get; set; }

	public ExpositionsPage()
	{
		InitializeComponent();
		Expositions = new List<Exposition>()
		{
			new Exposition() { Difficulty = 1, Description = "Maintain eye contact with a person on a street" },
			new Exposition() { Difficulty = 3, Description = "Say 'hi' to a stranger" },
            new Exposition() { Difficulty = 4, Description = "Ask a stranger for directions" },
			new Exposition() { Difficulty = 5, Description = "Go out with extravagant clothes on" },
            new Exposition() { Difficulty = 9,  Description = "Go on a date" },
            new Exposition() { Difficulty = 10, Description = "Present in front of people" },


        };
		carouselView.ItemsSource = Expositions;

    }

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//techniquesPage");
    }
}