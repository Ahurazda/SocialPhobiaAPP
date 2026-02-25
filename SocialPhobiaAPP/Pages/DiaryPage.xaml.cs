using CommunityToolkit.Maui.Core;
using SocialPhobiaAPP.Models;
using SocialPhobiaAPP.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;

namespace SocialPhobiaAPP.Pages;

public partial class DiaryPage : ContentPage
{
    public ObservableCollection<JournalEntry> DiaryEntries { get; set; }

    DatabaseService databaseService;
    public DiaryPage()
	{
		InitializeComponent();
        
        databaseService = new DatabaseService();
        DiaryEntries = new ObservableCollection<JournalEntry>();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadEntries();
        
    }

    private void setVisibility()
    {
        if (DiaryEntries.Count != 0)
        {

            emptinessIndicator.IsVisible = false;
            emptyDiaryImage.IsVisible = false;
        }
        else
        {
            emptinessIndicator.IsVisible = true;
            emptyDiaryImage.IsVisible = true;
        }
    }

    private async Task LoadEntries()
    {
        var entries = await databaseService.GetEntriesAsync();
        DiaryEntries.Clear();
        foreach (var entry in entries)
        {
            DiaryEntries.Add(entry);
        }

        setVisibility();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//editorDiaryPage");
    }

    private async void SwipeItem_Delete(object sender, EventArgs e)
    {
        if ( sender is SwipeItem entry )
        {
            var entryToDelete = entry.BindingContext as JournalEntry;                   // Gets an item, connected with the SwipeItem
            
            if ( entryToDelete == null) return;                                         // If not found, method terminates

            DiaryEntries.Remove(entryToDelete);                                         // Deletes item from ObservableCollection, which results in UI change

            setVisibility();
            notifytheUser();
            await databaseService.DeleteEntryAsync(entryToDelete);                      // Deletes item from database
        }
    }

    private async void notifytheUser()
    {
        string text = "The diary entry was deleted.";
        ToastDuration duration = ToastDuration.Short; //cca 2 seconds
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);
        await toast.Show();
    }


    private async void SwipeItem_Edit(object sender, EventArgs e)
    {
        if (sender is SwipeItem entry)
        {
            var entryToEdit = entry.BindingContext as JournalEntry;                         // Získá položku, která je spojena s tímto SwipeItem

            if (entryToEdit == null) return;                                                // Pokud není nalezena, ukonèí metodu

            var navigationParameter = new Dictionary<string, object>
            {
                { "Entry", entryToEdit }                                                    // Klíè je "Entry", hodnota je ten objekt
            };
                                                                                            // Navigujeme na stránku EditorPage
            await Shell.Current.GoToAsync("//editorDiaryPage", navigationParameter);
        }
    }
}