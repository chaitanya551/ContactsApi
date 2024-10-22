using ContactsApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactsApi.Data
{
    public class ContactsDataService : IContactsDataService
    {
        private readonly string _filePath = "Data/contacts.json";

        public ContactsDataService()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Contact> GetAllContacts()
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Contact>>(jsonData) ?? new List<Contact>();
        }

        public Contact GetContactById(int id)
        {
            var contacts = GetAllContacts();
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public void AddContact(Contact contact)
        {
            var contacts = GetAllContacts();
            contact.Id = contacts.Count > 0 ? contacts.Max(c => c.Id) + 1 : 0;
            contacts.Add(contact);
            SaveContacts(contacts);
        }

        public void UpdateContact(Contact contact)
        {
            var contacts = GetAllContacts();
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                SaveContacts(contacts);
            }
        }

        public void DeleteContact(int id)
        {
            var contacts = GetAllContacts();
            var contactToRemove = contacts.FirstOrDefault(c => c.Id == id);
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                SaveContacts(contacts);
            }
        }

        private void SaveContacts(List<Contact> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}