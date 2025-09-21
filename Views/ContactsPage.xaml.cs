using System.Collections.ObjectModel;
using Contacts.Models;
using Contact = Contacts.Models.Contact;

namespace Contacts.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
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

    private async void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (ContactsList.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?id={((Contact)ContactsList.SelectedItem).Id}");
        }
    }

    private void ContactsList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        ContactsList.SelectedItem = null;
    }

    private async void BtnAdd_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        var contact = (sender as MenuItem)?.CommandParameter as Contact;

        if (contact != null)
        {
            ContactRepository.Delete(contact.Id);
            LoadContacts();
        }
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        ContactsList.ItemsSource = new ObservableCollection<Contact>(ContactRepository.Search(((SearchBar)sender).Text));
    }
}