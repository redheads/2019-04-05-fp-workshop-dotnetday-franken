using System;
using System.Collections.Generic;
using ContactList.ValueObjects;
using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace ContactList.Tests
{
    public class ContactListTests
    {
        [Fact]
        public void Adding_new_contact_works()
        {
            var firstname = NonEmptyString.CreateBang("Homer");
            var lastname = NonEmptyString.CreateBang("Simpson");
            var id = Guid.NewGuid();
            var dateOfBirth = new DateTime(1956, 5, 12);
            var dob = Maybe<DateTime>.From(dateOfBirth);
            var twitterProfileUrl = NonEmptyString.Create("https://twitter.com/homerjsimpson");
            
            var contact = new Contact(
                id, 
                firstname, 
                lastname,
                dob, 
                twitterProfileUrl, 
                new EmailContact(), 
                new List<ContactMethod>());

            var sut = new ContactList();
            
            // important design decision: do we have state in ContactList or not?
            // should the following code return a modified list or have internal state?
            //
            // with state
            sut.AddContact(contact);
            //
            // without state
            ContactList newContactList = sut.AddContactFunctional(contact);

            true.Should().BeTrue();
        }
    }
}