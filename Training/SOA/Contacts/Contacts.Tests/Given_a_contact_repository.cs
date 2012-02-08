using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Contacts.Tests
{
	public class Given_a_contact_repository
	{
		[Fact]
		public void The_contacts_list_should_be_populated()
		{
			var repository = new ContactRepository();
			Assert.True(repository.Contacts.Any());
		}

		[Fact]
		public void An_existing_contact_should_be_retrievable()
		{
			var repository = new ContactRepository();
			var result = repository.Contacts.Single(c => c.Name.StartsWith("Katniss"));
			Assert.Equal("Katniss Everdeen", result.Name);
			Assert.Equal("88702091", result.Account);
		}
		
		[Fact]
		public void New_contacts_should_be_added_to_the_repository()
		{
			var repository = new ContactRepository();
			var contact = new Contact()
			{
				Id = new Guid(),
				Name = "Effie Trinket",
				Account = "254994573",
				Address = "Capitol",
				CreditCard = "5678901234561234",
				PinNumber = "5773"
			};
			repository.Add(contact);
			var result = repository.Contacts.Single(c => c.Name == "Effie Trinket");
			Assert.Equal(contact.Id, result.Id);
		}
	}
}
