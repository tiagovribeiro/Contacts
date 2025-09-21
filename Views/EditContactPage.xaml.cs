using Contacts.Models;

namespace Contacts.Views;

[QueryProperty(nameof(_Id), "id")]
public partial class EditContactPage : ContentPage
{
	public EditContactPage()
	{
		InitializeComponent();
	}

	public string _Id 
	{ 
		set
		{
			Contact = ContactRepository.Get(int.Parse(value));
			if(Contact != null)
			{
				contactControl.Name = Contact?.Name ?? "";
				contactControl.Email = Contact?.Email ?? "";
				contactControl.Phone = Contact?.Phone ?? "";
                contactControl.Adress = Contact?.Address ?? "";
			}
        } 
	}

    public Models.Contact? Contact { get; private set; }

    private async void ContactControl_OnSave(object sender, EventArgs e)
    {
        if (Contact != null)
        {
            Contact.Name = contactControl.Name;
            Contact.Email = contactControl.Email;
            Contact.Phone = contactControl.Phone;
            Contact.Address = contactControl.Adress;

            ContactRepository.Update(Contact.Id, Contact);
        }

        await Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    private void ContactControl_OnCancel(object sender, EventArgs e)
    {
        Contact = null;
        Shell.Current.GoToAsync("..");
    }

    private void ContactControl_OnError(object sender, string e)
    {
        DisplayAlert("Error", e.ToString(), "Ok");
    }
}