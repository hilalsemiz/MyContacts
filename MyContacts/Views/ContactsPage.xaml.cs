using Microsoft.Maui.ApplicationModel.Communication;
using MyContacts.Model;

namespace MyContacts.Views;

public partial class ContactsPage : ContentPage
{
    

    public ContactsPage()
    {
		InitializeComponent();
                ContactsList.ItemsSource = repository.GetAllContacts(); 

        
    }
     private void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedContact = e.SelectedItem as ContactInfo;
        if (selectedContact != null)
        {
            
            Shell.Current.GoToAsync(nameof(EditContactPage) + "?id=" + selectedContact.Id);
        }
    }

    
    private async void AddContactButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ContactsRepository contactsRepository = new ContactsRepository();

        ContactsList.ItemsSource=contactsRepository.GetContacts();
    }
    private void AddContactButton_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void ContactsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedContact = e.SelectedItem as ContactInfo;
        if(selectedContact != null) {
            Shell.Current.GoToAsync(nameof(EditContactPage)+"?id="+selectedContact.Id);

        }
    }
}
