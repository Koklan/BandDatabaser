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
        public void AddLink(Guid idBand, Guid? idAlbum, Guid idSong)
        {
            if (!db.Bands.Any(b => b.IdBand == idBand))
            {
                throw new Exception("Band id not found");
            }
            if (idAlbum != null)
            {
                if (!db.Albums.Any(s => s.IdAlbum == idAlbum))
                {
                    throw new Exception("Album id not found");
                }
            }
            if (!db.Songs.Any(s => s.IdSong == idSong))
            {
                throw new Exception("Song id not found");
            }
            BandAlbumSong newLink = new BandAlbumSong() { IdBand = idBand, IdAlbum = idAlbum, IdSong = idSong };
            db.BandAlbumSongs.InsertOnSubmit(newLink);
            db.SubmitChanges();
        }
    }
}
