using System;
using FluentAssertions;
using Xunit;

namespace ContactList.Tests
{
    public class EmailAddressTests
    {
        [Fact]
        public void Valid_email_has_correct_value()
        {
            // Arrange
            var validEmail = "foo@bar.de";

            // Act
            string result = new EmailAddress(validEmail);

            // Assert
            result.Should().Be(validEmail);
        }

        [Fact]
        public void Invalid_email_throws()
        {
            // Arrange
            var invalidEmail = "invalid";

            // Act
            Action action = () => new EmailAddress(invalidEmail);

            // Assert
            action.Should().Throw<Exception>();
        }
    }
}