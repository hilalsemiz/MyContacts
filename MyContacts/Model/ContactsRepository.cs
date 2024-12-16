using Microsoft.Data.Sqlite;
using System.Collections.ObjectModel;

namespace MyContacts.Model
{
    public class ContactsRepository
    {
        private const string connectionString = "Data Source=contacts.db;";

    
        public ObservableCollection<ContactInfo> GetContacts()
        {
            var contacts = new ObservableCollection<ContactInfo>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, NameSurname, PhoneNumber, Email FROM Contacts;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contacts.Add(new ContactInfo
                        {
                            Id = reader.GetInt32(0),
                            NameSurname = reader.GetString(1),
                            PhoneNumber = reader.GetString(2),
                            Email = reader.GetString(3)
                        });
                    }
                }
            }
            return contacts;
        }

    
        public void UpdateContact(ContactInfo contact)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    UPDATE Contacts 
                    SET NameSurname = @name, PhoneNumber = @phone, Email = @Email 
                    WHERE Id = @id;";

                command.Parameters.AddWithValue("@id", contact.Id);
                command.Parameters.AddWithValue("@name", contact.NameSurname);
                command.Parameters.AddWithValue("@phone", contact.PhoneNumber);
                command.Parameters.AddWithValue("@Email", contact.Email);

                command.ExecuteNonQuery();
            }
        }
    }
}
