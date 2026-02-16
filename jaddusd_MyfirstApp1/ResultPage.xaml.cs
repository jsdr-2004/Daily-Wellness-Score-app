namespace jaddusd_MyfirstApp1;

public partial class ResultPage : ContentPage
{
    private string _gender;
    private string _status;
    private int _score;

    public ResultPage(string gender, double sleep, double stress, double activity)
    {
        InitializeComponent();

        _gender = gender;

        _score = CalculateScore(sleep, stress, activity);
        _status = Classify(_score);

        ScoreLabel.Text = _score.ToString();
        StatusLabel.Text = _status;
    }

    private int CalculateScore(double sleep, double stress, double activity)
    {
        double rawScore = (sleep * 8.0) - (stress * 5.0) + (activity * 0.5);
        double clamped = Math.Max(0, Math.Min(100, rawScore));
        return (int)Math.Round(clamped);
    }

    private string Classify(int score)
    {
        if (score >= 80) return "Excellent";
        if (score >= 60) return "Good";
        if (score >= 40) return "Fair";
        return "Poor";
    }

    private async void OnRecommendationsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecommendationsPage(_status, _gender));
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
