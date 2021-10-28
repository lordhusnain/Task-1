using Model;
using System;

namespace CoreScrapper
{
    public interface IScrapper
    {
        HotelInfoModel Exrtact(string file);
    }
}
