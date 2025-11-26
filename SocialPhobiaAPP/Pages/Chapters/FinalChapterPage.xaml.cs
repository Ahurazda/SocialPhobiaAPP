namespace SocialPhobiaAPP.Pages.Chapters;

public partial class FinalChapterPage : ContentPage
{
	public FinalChapterPage()
	{
		InitializeComponent();
	}

    private async void FinishButton_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("///MainPage");
    }
}