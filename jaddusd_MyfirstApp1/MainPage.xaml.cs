namespace jaddusd_MyfirstApp1;

public partial class MainPage : ContentPage
{
    private string _gender = "Male"; // default selected

    public MainPage()
    {
        InitializeComponent();
        UpdateGenderUI();
        Recalculate();
    }

    private void OnMaleTapped(object sender, TappedEventArgs e)
    {
        _gender = "Male";
        UpdateGenderUI();
        Recalculate();
    }

    private void OnFemaleTapped(object sender, TappedEventArgs e)
    {
        _gender = "Female";
        UpdateGenderUI();
        Recalculate();
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        // Live labels
        SleepValueLabel.Text = $"{SleepSlider.Value:0.0} h";
        StressValueLabel.Text = $"{StressSlider.Value:0.0} / 10";
        ActivityValueLabel.Text = $"{ActivitySlider.Value:0} min";

        Recalculate();
    }

    private void Recalculate()
    {
        double sleep = SleepSlider.Value;
        double stress = StressSlider.Value;
        double activity = ActivitySlider.Value;

        // 1) Formula
        double rawScore = (sleep * 8.0) - (stress * 5.0) + (activity * 0.5);

        // 2) Clamp 0..100
        double clamped = Math.Max(0, Math.Min(100, rawScore));

        // 3) Round
        int finalScore = (int)Math.Round(clamped, MidpointRounding.AwayFromZero);

        ScoreLabel.Text = finalScore.ToString();

        string status = Classify(finalScore);
        StatusLabel.Text = status;

        RecommendationLabel.Text = GetRecommendation(_gender, status);
    }

    private static string Classify(int score)
    {
        if (score >= 80) return "Excellent";
        if (score >= 60) return "Good";
        if (score >= 40) return "Fair";
        return "Poor";
    }

    private static string GetRecommendation(string gender, string status)
    {
        bool isMale = gender == "Male";

        return status switch
        {
            "Excellent" => isMale
                ? "Maintain routine; include resistance training 2–3× per week; ensure protein intake across meals."
                : "Keep strong habits; add yoga/pilates for recovery; prioritize calcium + vitamin D intake.",

            "Good" => isMale
                ? "Improve recovery with an earlier bedtime; add 15 min of light cardio or stretching; keep hydration steady."
                : "Boost energy with a balanced breakfast; add 15 min of walking; focus on iron-rich foods if feeling low.",

            "Fair" => isMale
                ? "Aim for +1 hour of sleep; reduce caffeine after noon; schedule light mobility or an easy walk."
                : "Increase sleep consistency; reduce evening screen time; include calming routines like meditation or journaling.",

            _ => isMale
                ? "Rest today; avoid strenuous workouts; focus on hydration and 20–30 min of gentle walking."
                : "Prioritize rest and self-care; consider a short nap if possible; gentle yoga/stretching only."
        };
    }

    private void UpdateGenderUI()
    {
        // Selected = blue border + tinted bg
        if (_gender == "Male")
        {
            MaleCard.BorderColor = Color.FromArgb("#2563EB");
            MaleCard.BackgroundColor = Color.FromArgb("#E8F0FF");

            FemaleCard.BorderColor = Colors.Transparent;
            FemaleCard.BackgroundColor = Colors.White;
        }
        else
        {
            FemaleCard.BorderColor = Color.FromArgb("#2563EB");
            FemaleCard.BackgroundColor = Color.FromArgb("#E8F0FF");

            MaleCard.BorderColor = Colors.Transparent;
            MaleCard.BackgroundColor = Colors.White;
        }
    }
}
