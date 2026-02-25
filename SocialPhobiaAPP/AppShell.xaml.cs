
using SocialPhobiaAPP.Pages;
using SocialPhobiaAPP.Pages.Chapters;

namespace SocialPhobiaAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(EditorDiaryPage), typeof(EditorDiaryPage));
            Routing.RegisterRoute(nameof(BreathingPage), typeof(BreathingPage));
            Routing.RegisterRoute(nameof(MeditationPage), typeof(MeditationPage));
            Routing.RegisterRoute(nameof(ChapterPage), typeof(ChapterPage)); 
            Routing.RegisterRoute(nameof(FinalChapterPage), typeof(FinalChapterPage)); 
            Routing.RegisterRoute(nameof(ExpositionsPage), typeof(ExpositionsPage));

        }
    }
}


