using System.Collections.ObjectModel;
using Contacts.Models;
using ThemeMode.Services;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IThemeService _themeService;
    public ContactsPage(IThemeService themeService)
    {
        InitializeComponent();
        _themeService = themeService;
        _themeService.SetTheme(ThemeMode.ThemeOption.Ocean);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBarName.Text = string.Empty;
        LoadContacts();
    }

    private void LoadContacts()
    {
        ContactsList.ItemsSource = new ObservableCollection<Contact>(ContactRepository.Get());
    }

    private async void ContactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (((CollectionView)sender).SelectedItem != null)
        {
            var contact = e.CurrentSelection.FirstOrDefault() as Contact;
            if (contact != null)
            {
                await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={contact.Id}");

            }
            ((CollectionView)sender).SelectedItem = null;
        }
    }


    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Contact contact)
        {
            ContactRepository.Delete(contact.Id);
            LoadContacts();
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        ContactsList.ItemsSource = new ObservableCollection<Contact>(ContactRepository.Search(((SearchBar)sender).Text));
    }

    private async void testeAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(TestePage)}");
    }
}