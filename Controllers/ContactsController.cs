using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsDataService _dataService;

        public ContactsController(IContactsDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetAllContacts()
        {
            var contacts = _dataService.GetAllContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContactById(int id)
        {
            var contact = _dataService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public ActionResult AddContact([FromBody] Contact contact)
        {
            _dataService.AddContact(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateContact(int id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _dataService.UpdateContact(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            var contact = _dataService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _dataService.DeleteContact(id);
            return NoContent();
        }
    }
}