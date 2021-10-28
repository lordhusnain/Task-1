using NUnit.Framework;

namespace CoreScrapper.Test
{
    public class ScrapperTest
    {
        private IScrapper _scrapper;
        [SetUp]
        public void Setup()
        {
            _scrapper = new Scrapper();
        }

        [Test]
        public void HtmlFileShouldExist()
        {
            Assert.Pass();
        }

        [Test]
        public void HotelNameShouldComeCorrectly()
        {
            _scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");
            Assert.Pass();
        }
    }
}