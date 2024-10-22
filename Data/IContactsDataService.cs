using ContactsApi.Models;
using System.Collections.Generic;

namespace ContactsApi.Data
{
    public interface IContactsDataService
    {
        List<Contact> GetAllContacts();

        Contact GetContactById(int id);

        void AddContact(Contact contact);

        void UpdateContact(Contact contact);

        void DeleteContact(int id);
    }
}