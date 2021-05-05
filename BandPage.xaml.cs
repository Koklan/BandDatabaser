using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BandDatabaser
{
    /// <summary>
    /// Interaction logic for BandPage.xaml
    /// </summary>
    public partial class BandPage : Page
    {
        Database.DatabaseOperations datOp = new Database.DatabaseOperations();
        Database.Band bandObj = new Database.Band();
        Database.Album albumObj = new Database.Album();
        Database.Song songObj = new Database.Song();
        public BandPage()
        {
            InitializeComponent();
            Songs.Items.Clear();
            Albums.Items.Clear();
            LibraryPage libraryPage = new LibraryPage();
            List<Database.Band> bands = datOp.GetBandsForKeyword(libraryPage.SelectedBand).ToList();
            bandObj = bands[0];
            BandLabel.Content = bandObj.BandName;
            FoundationYearLabel.Content = "Foundation year:     " + bandObj.FoundationYear;
            List<Database.Album> albums = datOp.GetAlbumsForBand(bandObj.IdBand).ToList();
            foreach (var album in albums)
            {
                Albums.Items.Add(album.AlbumName);
            }
        }

        //public void Band(string band)
        //{
        //    List<Database.Band> bands = datOp.GetBandsForKeyword(band).ToList();
        //    bandObj = bands[0];
        //    BandLabel.Content = bandObj.BandName;
        //    FoundationYearLabel.Content = "Foundation year:     " + bandObj.FoundationYear;
        //    List<Database.Album> albums = datOp.GetAlbumsForBand(bandObj.IdBand).ToList();
        //    foreach (var album in albums)
        //    {
        //        Albums.Items.Add(album.AlbumName);
        //    }
        //}


        private void Albums_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Albums.SelectedItem != null)
            {
                Songs.Items.Clear();
                List<Database.Album> albums = datOp.GetAlbumsForKeyword(Albums.SelectedItem.ToString()).ToList();
                albumObj = albums[0];
                List<Database.Song> songs = datOp.GetSongsForAlbum(albumObj.IdAlbum).ToList();
                foreach (var song in songs)
                {
                    Albums.Items.Add(song.SongName);
                }
            }
        }

        private void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            if (AlbumNameBox != null)
            {
                datOp.AddAlbum(AlbumNameBox.Text);
                Songs.ItemsSource = datOp.GetSongsForAlbum(albumObj.IdAlbum).ToList();
            }
        }

        private void AddSongButton_Click(object sender, RoutedEventArgs e)
        {
            if (SongNameBox != null)
            {
                datOp.AddBandAlbumSong(bandObj.IdBand, albumObj.IdAlbum, datOp.AddSong(SongNameBox.Text));
            }
        }

        private void RemoveAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            if (Albums.SelectedItem != null)
            {
                datOp.RemoveAlbum(albumObj.IdAlbum);
            }
        }
        private void RemoveSongButton_Click(object sender, RoutedEventArgs e)
        {
            if (Songs.SelectedItem != null)
            {
                datOp.RemoveSong(songObj.IdSong);
            }
        }

        private void Songs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Database.Song> songs = datOp.GetSongsForKeyword(Songs.SelectedItem.ToString()).ToList();
            songObj = songs[0];
        }
        private void Albums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Database.Album> albums = datOp.GetAlbumsForKeyword(Albums.SelectedItem.ToString()).ToList();
            albumObj = albums[0];
        }
        
        private void Albums_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            List<Database.Album> albums = datOp.GetAlbumsForBand(bandObj.IdBand).ToList();
            foreach (var album in albums)
            {
                Albums.Items.Add(album.AlbumName);
            }
        }

        private void Songs_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            List<Database.Song> songs = datOp.GetSongsForAlbum(songObj.IdSong).ToList();
            foreach (var song in songs)
            {
                Songs.Items.Add(song.SongName);
            }
        }
    }
}
