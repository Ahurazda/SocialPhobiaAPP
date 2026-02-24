namespace SocialPhobiaAPP.Pages;

public partial class BreathingPage : ContentPage
{
    private CancellationTokenSource _cts;
    private bool _isAnimating = false;

    public BreathingPage()
    {
        InitializeComponent();
    }

    // Tato metoda se zavolá automaticky, když uživatel opouští stránku
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        StopBreathingLogic(); // Ujistíme se, že se vše zastaví pøi odchodu
    }

    private async void StartBreathing_Clicked(object sender, EventArgs e)
    {
        if (_isAnimating)
        {
            StopBreathingLogic();
            return;
        }

        await StartBreathingLogic();
    }

    private async Task StartBreathingLogic()
    {
        _isAnimating = true;
        _cts = new CancellationTokenSource();
        var token = _cts.Token;
        BreathingButton.Text = "Stop the breathing";

        try
        {
            while (!token.IsCancellationRequested)
            {
               
                InstructionLabel.Text = "Breathe in...";
                await BreathingCircle.ScaleToAsync(2, 4000, Easing.CubicInOut);
                if (token.IsCancellationRequested) break;

                InstructionLabel.Text = "Hold the breath...";
                await Task.Delay(7000, token);

                InstructionLabel.Text = "Breathe out...";
                await BreathingCircle.ScaleToAsync(1, 8000, Easing.CubicInOut);
                if (token.IsCancellationRequested) break;
            }
        }
        catch (OperationCanceledException)
        {
            
        }
        finally
        {
            await ResetCircleToOriginalState();
        }
    }

    private async void StopBreathingLogic()
    {
        _cts?.Cancel();
        _cts = null;
        _isAnimating = false;

        BreathingCircle.CancelAnimations();
        await ResetCircleToOriginalState();
        BreathingButton.Text = "Start the breathing";
    }

    private async Task ResetCircleToOriginalState()
    {
        _isAnimating = false;
        InstructionLabel.Text = "Get prepared...";

        await BreathingCircle.ScaleToAsync(1, 200, Easing.CubicOut);
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        StopBreathingLogic(); 
        await Shell.Current.GoToAsync("//techniquesPage");
    }
}