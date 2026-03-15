namespace SocialPhobiaAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Current.RequestedThemeChanged += OnThemeChanged;
        }

        
        private void OnThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            
            
        }
        

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}