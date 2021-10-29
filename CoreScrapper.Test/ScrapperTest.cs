using NUnit.Framework;
using System;

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
        public void HotelNameShouldComeCorrectly()
        {
            var model = _scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");
            Assert.AreEqual(model.Name, "Kempinski Hotel Bristol Berlin");
        }

        [Test]
        public void NumberOfReviewsShouldComeCorrectly()
        {
            var model = _scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");
            Assert.AreEqual(model.NumberOfReviews, "1401");
        }

        [Test]
        public void RoomCategoriesShouldComeCorrectly()
        {
            var model = _scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");
            Assert.AreEqual(model.RoomCategories.Count, 7);
        }

        [Test]
        public void AlternativeHotelsShouldComeCorrectly()
        {
            var model = _scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");
            Assert.AreEqual(model.AlternativeHotels.Count, 4);
        }
    }
}