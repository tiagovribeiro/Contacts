using Contacts.Models;

namespace Contacts.Views;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }

    public Models.Contact? Contact { get; private set; }

    private async void ContactControl_OnSave(object sender, EventArgs e)
    {
        Contact = new();
        Contact.Name = contactControl.Name;
        Contact.Email = contactControl.Email;
        Contact.Phone = contactControl.Phone;
        Contact.Address = contactControl.Adress;
        ContactRepository.Add(Contact);
        await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private async void ContactControl_OnCancel(object sender, EventArgs e)
    {
        Contact = null;
        await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e.ToString(), "Ok");
    }
}