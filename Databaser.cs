using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BandDatabaser
{
    public static class Databaser
    {
        //used for debug purposes for now, later will act as the link class between database and UI
        public static void test()
        {
            Database.DatabaseOperations datOp = new Database.DatabaseOperations();
            /*
            Guid bandId1 = datOp.AddBand("Alestorm");
            Guid bandId2 = datOp.AddBand("Amon Amarth");
            Guid albumId1 = datOp.AddAlbum("Sunset on the Golden Age");
            Guid albumId2 = datOp.AddAlbum("Curse of the Crystal Coconut");
            datOp.AddBandAlbumSong(bandId1, albumId1, datOp.AddSong("Drink"));
            datOp.AddBandAlbumSong(bandId1, albumId1, datOp.AddSong("Magnetic North"));
            datOp.AddBandAlbumSong(bandId1, null, datOp.AddSong("Tortuga"));
            var a = datOp.GetAlbumsForBand(bandId1);
            var b = datOp.GetSongsForAlbum(albumId1);
            var c = datOp.GetBandsForKeyword("");
            var d = datOp.GetSongsForKeyword("t");
            datOp.SaveToCSV("C:/File export/database.csv");
            */
            datOp.LoadFromCSV("C:/File export/database.csv");
        }
    }
}
