using Contacts.Views;

namespace Contacts
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private static void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
        }
    }
}
