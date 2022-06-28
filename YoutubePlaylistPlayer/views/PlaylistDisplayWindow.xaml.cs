using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using SimpleYoutubePlaylist;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace YoutubePlaylistPlayer.views
{



    /// <summary>
    /// Interaction logic for PlaylistDisplayWindow.xaml
    /// </summary>
    public partial class PlaylistDisplayWindow : INotifyPropertyChanged
    {

        const string temp_playlist_path = @"C:\Users\Nicholas\Documents\C# Projects\config settings\YoutubePlaylistPlayer\playlists.json";

        public PlaylistDisplayWindow(MainWindow mainWindow, string targetPlaylist, string apiKey)
        {
            DataContext = this;
            InitializeComponent();

            this.mainWindow = mainWindow;

            var videos = new YouTubeVideo(targetPlaylist, apiKey, 100).GetVideoData();

            playlistName = "Default Playlist Name";

            foreach(var video in videos)
            {
                PlaylistVideoItemsData.Add(new YoutubePlaylistVideo
                {
                    ytplv_ImageSource = video.ThumbnailSrc,
                    ytplv_Name = video.Title,
                    ytplv_VideoLength = "N/A",
                    ytplv_ScriptInstructions = "None",
                    ytplv_IgnoreVideo = false
                });
            }

            videosList.ItemsSource = PlaylistVideoItemsData;
        }

        public void SavePlaylist()
        {
            List<YoutubePlaylist> playlist_list = new List<YoutubePlaylist>();

            if (File.Exists(temp_playlist_path))
            {
                var json = File.ReadAllText(temp_playlist_path);
                var current_playlist = JsonConvert.DeserializeObject<List<YoutubePlaylist>>(json);
                playlist_list.AddRange(current_playlist);
                File.Delete(temp_playlist_path);
            }

            //Create the file.
            YoutubePlaylist playlist = new YoutubePlaylist(playlistName, PlaylistVideoItemsData.ToList());
            
            playlist_list.Add(playlist);
            string playlist_json = JsonConvert.SerializeObject(playlist_list);
            File.WriteAllText(temp_playlist_path, playlist_json);          
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            SavePlaylist();
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public ObservableCollection<YoutubePlaylistVideo> PlaylistVideoItemsData { get { return _PlaylistVideoItemsData; } }
        ObservableCollection<YoutubePlaylistVideo> _PlaylistVideoItemsData = new ObservableCollection<YoutubePlaylistVideo>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow mainWindow = null;

        public string _playlistName = string.Empty;
        public string playlistName { get { return _playlistName; } set { _playlistName = value; OnPropertyChanged(); } }
    }

    public class YoutubePlaylistVideo
    {
        public string ytplv_ImageSource { get; set; }
        public string ytplv_Name { get; set; }
        public string ytplv_VideoLength { get; set; }      
        public string ytplv_ScriptInstructions { get; set; }
        public bool ytplv_IgnoreVideo { get; set; }
    }

    public class YoutubePlaylist
    {


        public YoutubePlaylist(string playlistName, List<YoutubePlaylistVideo> playlistInfo)
        {
            this.playlistName = playlistName;
            this.playlistInfo = playlistInfo;
        }

        public string playlistName { get; set; }
        public List<YoutubePlaylistVideo> playlistInfo { get; set; }
    }
}
