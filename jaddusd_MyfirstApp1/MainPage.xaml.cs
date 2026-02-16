namespace jaddusd_MyfirstApp1;

public partial class MainPage : ContentPage
{
    private string _gender = "Male";

    public MainPage()
    {
        InitializeComponent();
        UpdateGenderUI();
    }

    private void OnMaleTapped(object sender, TappedEventArgs e)
    {
        _gender = "Male";
        UpdateGenderUI();
    }

    private void OnFemaleTapped(object sender, TappedEventArgs e)
    {
        _gender = "Female";
        UpdateGenderUI();
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        SleepValueLabel.Text = $"{SleepSlider.Value:0.0} h";
        StressValueLabel.Text = $"{StressSlider.Value:0.0} / 10";
        ActivityValueLabel.Text = $"{ActivitySlider.Value:0} min";
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(
            new ResultPage(
                _gender,
                SleepSlider.Value,
                StressSlider.Value,
                ActivitySlider.Value));
    }

    private void UpdateGenderUI()
    {
        if (_gender == "Male")
        {
            MaleCard.BorderColor = Colors.Blue;
            FemaleCard.BorderColor = Colors.Transparent;
        }
        else
        {
            FemaleCard.BorderColor = Colors.Blue;
            MaleCard.BorderColor = Colors.Transparent;
        }
    }
}
