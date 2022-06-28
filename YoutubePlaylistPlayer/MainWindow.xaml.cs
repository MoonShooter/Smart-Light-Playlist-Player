using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Web.WebView2.Core;
using SimpleYoutubePlaylist;
using YoutubePlaylistPlayer.services;
using YoutubePlaylistPlayer.views;

namespace YoutubePlaylistPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        //These should probably get stored in some sort of config file... consider doing it like a json.
        const string temp_api_key = "AIzaSyCPrM-mhMRW2K9EwXeTq6yQNGU0oddrGnY";
        const string temp_channel_key = "UClD2AKBeZz25QSKU2XmZX6w";
        const string temp_playlist_key = "PLrG1iouQgY9ELnwlPPVEoC9Fd-6_8cOzf";


        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();

            SmartDeviceCommsService service = new SmartDeviceCommsService();
            

            //StringBuilder sb = new StringBuilder();
            //sb.Append(@"C:\Users\Nicholas\Documents\C# Projects\YoutubePlaylistPlayer\YoutubePlaylistPlayer\");
            //sb.Append(@"Html\YoutubePlayer.html");
            //Console.WriteLine(sb.ToString());
            //wv_MainWebView.Source = new Uri(sb.ToString());

            playlistName = "No Playlist Selected";
        }

        async void InitializeAsync()
        {
            await wv_MainWebView.EnsureCoreWebView2Async();
            //wv_MainWebView.CoreWebView2.WebMessageReceived +- ""
        }

        #region Functions

        public void CreateYoutubePlaylist(string id, Window prevWindow)
        {
            try
            {
                prevWindow.Close();
                var targetPlaylist = new YouTubeVideo(id, temp_api_key, 1000).GetVideoData();
                var youtubePlaylistWindow = new PlaylistDisplayWindow(this, id, temp_api_key);
                youtubePlaylistWindow.Show();
            }
            catch(Exception e)
            {

            }

        }

        public void CreateOfflinePlaylist()
        {

        }

        public void CreateMixedPlaylist()
        {

        }

        #endregion

        #region Button Events

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Create_New_Scene_Script_Click(object sender, RoutedEventArgs e)
        {
            var window = new PlaylistTypeSelectionWindow(this, temp_api_key);
            window.Show();
        }

        private void Play_Playlist_Click(object sender, RoutedEventArgs e)
        {
            var playlists = new YouTubePlayList(temp_channel_key, temp_api_key, 100).GetPlaylistData();
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"----PLAYLIST : {playlist.Title}----");
                var videos = new YouTubeVideo(playlist.ID, temp_api_key, 100).GetVideoData();
                foreach(var video in videos)
                {
                    Console.WriteLine(video.Title);
                }
            }
        }

        private void Play_Button_Click(object sender, RoutedEventArgs e)
        {
            wv_MainWebView.CoreWebView2.ExecuteScriptAsync("" +
                "var ytplayer = document.getElementById('movie_player');" +
                "ytplayer.playVideo(); ");
        }

        private void Pause_Button_Click(object sender, RoutedEventArgs e)
        {

            wv_MainWebView.CoreWebView2.ExecuteScriptAsync("" +
                "var ytplayer = document.getElementById('movie_player');" +
                "ytplayer.pauseVideo(); ");
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainWindow mainWindow = null;

        public string _playlistName = "No Playlist Selected";
        public string playlistName { get { return _playlistName; } set { _playlistName = value; OnPropertyChanged(); } }
    }
}
