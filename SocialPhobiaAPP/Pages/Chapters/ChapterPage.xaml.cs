using SocialPhobiaAPP.ViewModels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialPhobiaAPP.Pages.Chapters;

[QueryProperty(nameof(Name), "name")]
public partial class ChapterPage : ContentPage
{


    ChapterViewModel vm;
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            vm.LoadChapterByName(_name);
        }
    }

   

    public ChapterPage()
    {
        InitializeComponent();
        vm = new ChapterViewModel();
        BindingContext = vm;
    }

   

    private async void Next_Clicked(object sender, EventArgs e)
    {
        int lastIndex = vm.sections.Count - 1;
        if ( vm.Index == lastIndex )
        {
            vibrate();
            await Shell.Current.GoToAsync("//finalChapterPage");

        } else {
            if (vm.Index < lastIndex)
                vm.Index++;
        }
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        if (vm.Index > 0)
        {
            vm.Index--;
            
        }
    }

    private void vibrate()
    {
        try
        {
            int vibrationTime = 500;
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(vibrationTime));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Vibration failed: {ex.Message}");
        }
    }

    private async void Close_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
    
}