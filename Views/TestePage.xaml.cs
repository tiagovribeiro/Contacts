using System.Collections.ObjectModel;

namespace Contacts.Views;

public partial class TestePage : ContentPage
{
    public TestePage()
    {
        InitializeComponent();

        MyButtonGroup.Buttons = new ObservableCollection<Button>
        {
            new Button
            {
                Text = "S",
                Command = new Command(() => DisplayAlert("Save", "Save clicked", "OK")),
                HorizontalOptions = LayoutOptions.Start, // don’t stretch
                VerticalOptions = LayoutOptions.Center,  // keep middle aligned
                WidthRequest = 20,
                HeightRequest = 20,
                CornerRadius = 0,
                BorderWidth = 1
            },
            new Button
            {
                Text = "C",
                Command = new Command(() =>
                DisplayAlert("Cancel", "Cancel clicked", "OK")),
                HorizontalOptions = LayoutOptions.Start, // don’t stretch
                VerticalOptions = LayoutOptions.Center,  // keep middle aligned
                WidthRequest = 20,
                HeightRequest = 20,
                CornerRadius = 0,
                BorderColor = Colors.BlueViolet,
                BorderWidth = 1
            },
            new Button
            {
                Text = "H",
                Command = new Command(() => DisplayAlert("Help", "Help clicked", "OK")),
                HorizontalOptions = LayoutOptions.Start, // don’t stretch
                VerticalOptions = LayoutOptions.Center,  // keep middle aligned
                WidthRequest = 20,
                HeightRequest = 20,
                CornerRadius = 0,
                BorderWidth = 1

            }
        };
    }
}

