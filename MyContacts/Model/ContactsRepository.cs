using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
         static List<ContactInfo> contacts = new List<ContactInfo>() { 
                    new ContactInfo {Id=1, NameSurname="Hüseyin Şimşek", Email="huseyinsimsek@gmail", PhoneNumber="053357252"}
                    };
        static int maxId = 2;
        public ContactsRepository()
        {
            
        }

        public ObservableCollection<ContactInfo> GetContacts() {
            return new ObservableCollection<ContactInfo>( contacts);

        }

        public void AddContact(ContactInfo contact)
        {
            contact.Id = maxId++;
            contacts.Add(contact);
        }

        public ContactInfo GetContact(int id)
        {
            return contacts.FirstOrDefault( c => c.Id==id ) ;
        }
        public void UpdateContact(ContactInfo contact)
{
    var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
    if (existingContact != null)
    {
        existingContact.NameSurname = contact.NameSurname;
        existingContact.PhoneNumber = contact.PhoneNumber;
        existingContact.Email = contact.Email;
    }
}
        private List<ContactInfo> contacts;

        public ContactRepository()
        {
        
            contacts = new List<ContactInfo>
            {
                new ContactInfo { Id = 1, NameSurname = "Ali Yılmaz", PhoneNumber = "1234567890", Email = "ali@example.com" },
                new ContactInfo { Id = 2, NameSurname = "Ayşe Demir", PhoneNumber = "9876543210", Email = "ayse@example.com" }
            };
        }


        public List<ContactInfo> GetContacts()
        {
            return contacts;
        }

    
        public ContactInfo GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateContact(ContactInfo contact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.NameSurname = contact.NameSurname;
                existingContact.PhoneNumber = contact.PhoneNumber;
                existingContact.Email = contact.Email;
            }
        }

    }
}
