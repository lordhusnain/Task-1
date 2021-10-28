using HtmlAgilityPack;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CoreScrapper
{
    public class Scrapper : IScrapper
    {
        public HotelInfoModel Exrtact(string file)
        {
            HotelInfoModel model;
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), file);
                var doc = new HtmlDocument();
                doc.Load(path);

                model = new HotelInfoModel();
                var nameNode = doc.DocumentNode.SelectSingleNode("//div[@class='details']/h3");
                model.Name = nameNode.InnerText;

                var addressNode = doc.DocumentNode.SelectSingleNode("//span[@id='hp_address_subtitle']");
                model.Address = addressNode.InnerText;

                var ratingNode = doc.DocumentNode.SelectSingleNode("//div[@id='js--hp-gallery-scorecard']/a/span[@class='rating notranslate']");
                model.ReviewPoints = ratingNode.InnerText;

                var numberOfReviewsNode = doc.DocumentNode.SelectSingleNode("//div[@id='js--hp-gallery-scorecard']/span[@class='trackit score_from_number_of_reviews']/strong");
                model.NumberOfReviews = numberOfReviewsNode.InnerText;

                var descriptionNode = doc.DocumentNode.SelectNodes("//div[@id='summary']/p");
                var description = string.Join("", descriptionNode.Select(c => c.InnerText));
                model.Description = description;

                foreach (HtmlNode row in doc.DocumentNode.SelectNodes("//table[@id='maxotel_rooms']/tbody/tr"))
                {
                    model.RoomCategories.Add(row.SelectNodes("td[@class='ftd']").FirstOrDefault()?.InnerText);
                }

                foreach (HtmlNode row in doc.DocumentNode.SelectNodes("//table[@id='althotelsTable']/tbody/tr"))
                {
                    foreach (HtmlNode col in row.SelectNodes("//td[@class='althotelsCell tracked']"))
                    {
                        model.AlternativeHotels.Add(col.SelectNodes("p/a").FirstOrDefault()?.InnerText);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return model;
        }
    }
}
