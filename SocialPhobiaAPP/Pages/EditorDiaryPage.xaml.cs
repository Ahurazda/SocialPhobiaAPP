using CommunityToolkit.Maui.Core;
using SocialPhobiaAPP.Models;
using SocialPhobiaAPP.Services;
using CommunityToolkit.Maui.Alerts;

using System.Threading.Tasks;

namespace SocialPhobiaAPP.Pages;

[QueryProperty(nameof(JournalEntryToEdit), "Entry")]
public partial class EditorDiaryPage : ContentPage
{


    DatabaseService databaseService;
    private JournalEntry _journalEntryToEdit;
    public JournalEntry JournalEntryToEdit
    {
        get => _journalEntryToEdit;
        set
        {
            _journalEntryToEdit = value;
            // Jakmile data dorazí, naplníme ovládací prvky
            if (_journalEntryToEdit != null)
            {
                TitleEntry.Text = _journalEntryToEdit.Title;
                ContentEditor.Text = _journalEntryToEdit.Content;
            }
        }
    }
    public EditorDiaryPage()
	{
		InitializeComponent();
        databaseService = new DatabaseService();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LabelText.Text = (JournalEntryToEdit != null) ? "Diary entry editation" : "New diary entry";

    }
    private async void  ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//diaryPage");
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string content = ContentEditor.Text;
        string message;
            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(content))
            {

                var newEntry = new Models.JournalEntry
                {
                    Title = title,
                    Content = content,
                    CreatedAt = DateTime.Now
                };

                if ( JournalEntryToEdit != null)  // Pokud upravujeme existující položku
                {
                    newEntry.ID = JournalEntryToEdit.ID;               // Zachováme pùvodní ID                   
                    await databaseService.UpdateEntryAsync(newEntry);  // Aktualizujeme položku v databázi
                }
                else
                    await databaseService.SaveEntryAsync(newEntry);     // Save the new entry to the database
            
            message = ( JournalEntryToEdit != null) ? "Diary entry was updated" : "New diary entry added";
            notifyTheUser(message);  // Notify the user that the entry was saved
            TitleEntry.Text = string.Empty;  ContentEditor.Text = string.Empty;
            JournalEntryToEdit = null;  // Resetujeme pro pøípad dalšího použití

            await Shell.Current.GoToAsync("//diaryPage");       // Navigate back to the diary page to see the new entry
            }
        

        }
    


    private async void notifyTheUser(string message)
    {
        
        ToastDuration duration = ToastDuration.Short; // Cca 2 seconds
        double fontSize = 14;

        var toast = Toast.Make(message, duration, fontSize);
        await toast.Show();
    }

    
}