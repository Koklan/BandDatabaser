using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BandDatabaser.Database
{
    public class DatabaseOperations
    {
        DatabaseClassesDataContext db = new DatabaseClassesDataContext();
        public Guid AddBand(string bandName, int? foundationYear = null, int? idPic = null)
        {
            //nullable int to nullable date
            DateTime? intToDate = null;
            if (foundationYear.HasValue)
            {
                intToDate = new DateTime(foundationYear.Value);
            }
            Band newBand = new Band() { BandName = bandName, FoundationYear = intToDate, IdPic = idPic };
            db.Bands.InsertOnSubmit(newBand);
            db.SubmitChanges();
            return newBand.IdBand;
        }
        public Guid AddAlbum(string albumName, int? productionYear = null, int? idPic = null)
        {
            //nullable int to nullable date
            DateTime? intToDate = null;
            if (productionYear.HasValue)
            {
                intToDate = new DateTime(productionYear.Value);
            }
            Album newAlbum = new Album() { AlbumName = albumName, ProductionYear = intToDate, IdPic = idPic };
            db.Albums.InsertOnSubmit(newAlbum);
            db.SubmitChanges();
            return newAlbum.IdAlbum;
        }
        public Guid AddSong(string songName)
        {
            Song newSong = new Song() { SongName = songName };
            db.Songs.InsertOnSubmit(newSong);
            db.SubmitChanges();
            return newSong.IdSong;
        }
    }
}
