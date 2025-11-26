
using SocialPhobiaAPP.Pages;
using SocialPhobiaAPP.Pages.Chapters;

namespace SocialPhobiaAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(DiaryPage), typeof(DiaryPage));

            Routing.RegisterRoute(nameof(ChapterPage), typeof(ChapterPage)); // Ensure ChapterPage exists in the correct namespace
            Routing.RegisterRoute(nameof(FinalChapterPage), typeof(FinalChapterPage)); // Ensure ChapterPage exists in the correct namespace

        }
    }
}


