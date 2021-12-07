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
            _sut = new LoginToEmail("name@test.com", "password", "Smtp Host", /*Port*/ 321);
        }

        /*Make sure your security level is public before testing*/
        [Theory]
        [InlineData("name@test.com")]
        [InlineData("na.me@test.com")]
        [InlineData("mr.pp.ramos@test.com")]
        [InlineData("name@test.com.pt")]
        [InlineData("name@test.a.b.c")]
        [InlineData("na-me@test.com")]
        public void Email_ItIsAnEmaisFeature_ReturnInvalidEmail(string _)
        {
            bool result = _sut.IsEmailAddressValid(_);
            Assert.True(result, "Do not match!");
        }

        /*Make sure your security level is public before testing*/
        [Theory]
        [InlineData("name_test.com")]
        [InlineData("name_test_com")]
        [InlineData("name@test_com")]
        [InlineData("@name_test.com")]
        [InlineData("na@me@test.com")]
        [InlineData("name@test.c@m")]
        [InlineData("name_test.com@")]
        [InlineData(".name@test_com")]
        [InlineData("name@test_com.")]
        [InlineData("name.@test.com")]
        [InlineData("name@.test.com")]
        [InlineData(" name@test.com")]
        [InlineData("name@test.com ")]
        [InlineData("name @test.com")]
        [InlineData("name@ test.com")]
        [InlineData("name@test .com")]
        [InlineData("name@test. com")]
        [InlineData("na me@test.com")]
        [InlineData("name@te st.com")]
        public void Email_ItIsNotAnEmaisFeature_ReturnInvalidEmail(string _)
        {
            bool result = _sut.IsEmailAddressValid(_);
            Assert.False(result, "Do not match!");
        }

        /*Make sure your security level is public before testing*/
        [Theory]
        [InlineData("name@gmail.com", "smtp.gmail.com")]
        [InlineData("name@yahoo.com", "smtp.mail.yahoo.com")]
        [InlineData("name@hotmail.com", "smtp.live.com")]
        [InlineData("name@live.com", "smtp.live.com")]
        [InlineData("name@company.com", "smtp.gmail.com")]
        public void Email_WhichSmtpToChoose_ChooseTheBest(string _ , string _c ) 
        {
            var MustMatchWith = _sut.findSmtp(_);
            Assert.Matches( MustMatchWith , _c);
        }

    }
}
