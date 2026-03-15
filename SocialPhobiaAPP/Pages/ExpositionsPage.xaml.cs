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
			new Exposition() { Difficulty = "Easy", Description = "Maintain eye contact with a person on a street" },
			new Exposition() { Difficulty = "Easy", Description = "Say 'hi' to a stranger" },
            new Exposition() { Difficulty = "Medium", Description = "Ask a stranger for directions" },
            new Exposition() { Difficulty = "Medium", Description = "Give compliment to a stranger" },
            new Exposition() { Difficulty = "Medium", Description = "Go out with extravagant clothes on" },
            new Exposition() { Difficulty = "Hard",  Description = "Go on a date" },
            new Exposition() { Difficulty = "Hard", Description = "Present in front of people" },


        };
		carouselView.ItemsSource = Expositions;

    }

	private async void BackButton_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//techniquesPage");
    }
}