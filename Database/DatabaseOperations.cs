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
        public void RemoveBand(Guid idBand)
        {
            db.Bands.DeleteOnSubmit(db.Bands.Single(b => b.IdBand == idBand));
            db.SubmitChanges();
        }
        public void RemoveAlbum(Guid idAlbum)
        {
            db.Albums.DeleteOnSubmit(db.Albums.Single(a => a.IdAlbum == idAlbum));
            db.SubmitChanges();
        }
        public void RemoveSong(Guid idSong)
        {
            db.Songs.DeleteOnSubmit(db.Songs.Single(s => s.IdSong == idSong));
            db.SubmitChanges();
        }
        public void RemoveLink(Guid idBand, Guid? idAlbum, Guid idSong)
        {
            db.BandAlbumSongs.DeleteOnSubmit(db.BandAlbumSongs.Single(l => (l.IdSong == idSong && l.IdAlbum == idAlbum && l.IdSong == idAlbum)));
            db.SubmitChanges();
        }
        public List<Album> GetAlbumsForBand(Guid idBand)
        {
            return (from bas in db.BandAlbumSongs
                    where bas.IdBand == idBand
                    orderby bas.Album.ProductionYear descending
                    group bas by bas.IdAlbum into b
                    select b.First().Album)
                    .ToList<Album>();
        }
        public List<Song> GetSongsForAlbum(Guid idAlbum)
        {
            return (from bas in db.BandAlbumSongs
                    where bas.IdAlbum == idAlbum
                    group bas by bas.IdSong into b
                    select b.First().Song)
                    .ToList<Song>();
        }
        public List<Band> GetBandsForKeyword(string keyword)
        {
            return (from b in db.Bands
                    where b.BandName.ToLower().StartsWith(keyword.ToLower())
                    orderby b.BandName ascending
                    select b).ToList<Band>();
        }
        public List<Album> GetAlbumsForKeyword(string keyword)
        {
            return (from a in db.Albums
                    where a.AlbumName.ToLower().StartsWith(keyword.ToLower())
                    orderby a.AlbumName ascending
                    select a).ToList<Album>();
        }
        public List<Song> GetSongsForKeyword(string keyword)
        {
            return (from s in db.Songs
                    where s.SongName.ToLower().StartsWith(keyword.ToLower())
                    orderby s.SongName ascending
                    select s).ToList<Song>();
        }
    }
}
