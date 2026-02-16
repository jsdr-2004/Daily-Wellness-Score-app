namespace jaddusd_MyfirstApp1;

public partial class RecommendationsPage : ContentPage
{
    public RecommendationsPage(string status, string gender)
    {
        InitializeComponent();
        RecommendationLabel.Text = GetRecommendation(status, gender);
    }

    private string GetRecommendation(string status, string gender)
    {
        bool isMale = gender == "Male";

        return status switch
        {
            "Excellent" => isMale
                ? "Maintain routine; include resistance training 2–3× per week; ensure protein intake across meals."
                : "Keep strong habits; add yoga/pilates; prioritize calcium + vitamin D.",

            "Good" => isMale
                ? "Earlier bedtime; add 15 min cardio; stay hydrated."
                : "Balanced breakfast; 15 min walking; iron-rich foods.",

            "Fair" => isMale
                ? "Add 1 hour sleep; reduce caffeine; mobility walk."
                : "Improve sleep consistency; reduce screen time; meditation.",

            _ => isMale
                ? "Rest today; hydrate; 20–30 min gentle walk."
                : "Prioritize rest; short nap; gentle yoga/stretching."
        };
    }

    private async void OnBackResults(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnBackInputs(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
