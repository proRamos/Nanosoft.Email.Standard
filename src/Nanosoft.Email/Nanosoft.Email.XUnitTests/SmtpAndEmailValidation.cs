using System;
using Xunit;
using Nanosoft.Email;

namespace Nanosoft.Email.XUnitTests
{
    public class SmtpAndEmailValidation

    {
        private readonly LoginToEmail _sut;

        public SmtpAndEmailValidation()
        {
            _sut = new LoginToEmail("name@test.com", "password");
        }

        [Theory]
        [InlineData("name_test.com")]
        [InlineData("name@test_com")]
        [InlineData("@name_test.com")]
        [InlineData("name_test.com@")]
        [InlineData(".name@test_com")]
        [InlineData("name@test_com.")]
        public void Email_ItIsNotAnEmaisFeature_ReturnInvalidEmail(string _ )
        {
            Action atual = () => _sut.IsEmailAddressValid( _ );
            Assert.Throws<ArgumentException>(atual);
        }

        [Theory]
        [InlineData("name@gmail.com", "smtp.gmail.com")]
        [InlineData("name@yahoo.com", "smtp.mail.yahoo.com")]
        [InlineData("name@hotmail.com", "smtp.live.com")]
        [InlineData("name@company.com", "smtp.gmail.com")]
        public void Email_WhichSmtpToChoose_ChooseTheBest(string _ , string _c ) 
        {
            var MustMatchWith = _sut.findSmtp(_);
            Assert.Matches( MustMatchWith , _c);
        }
    }
}
