using SocialPhobiaAPP.ViewModels;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialPhobiaAPP.Pages.Chapters;

[QueryProperty(nameof(Name), "name")]
public partial class ChapterPage : ContentPage
{


    ChapterViewModel vm;
    
    private string _name;

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
            await Shell.Current.GoToAsync("/FinalChapterPage");

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


    private async void Close_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
    
}