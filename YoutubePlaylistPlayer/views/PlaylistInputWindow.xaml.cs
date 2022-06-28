using SimpleYoutubePlaylist;
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
using System.Windows.Shapes;

namespace YoutubePlaylistPlayer.views
{
    /// <summary>
    /// Interaction logic for PlaylistInputWindow.xaml
    /// </summary>
    public partial class PlaylistInputWindow : INotifyPropertyChanged
    {
        public PlaylistInputWindow(Window prevWindow, string playlistType, string apiKey)
        {           
            this.prevWindow = prevWindow;
            this.playlistType = playlistType;
            this.apiKey = apiKey;
            InitializeComponent();
            SetRequestText();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tag = ((Button)sender).Tag;
            if(tag.Equals("Cancel"))
            {
                Close();
            }
            else
            {
                HandleTextboxInput();
            }
        }

        private void SetRequestText()
        {
            switch (playlistType)
            {
                case "Youtube":
                    RequestText.Content = "Please enter the ID of the playlist you would like";
                    break;
                case "Offline":
                    break;
                default:
                    Console.WriteLine($"No {playlistType} playlist property identified.");
                    break;
            }
        }

        private void HandleTextboxInput()
        {
            switch (playlistType)
            {
                case "Youtube":
                    try
                    {
                        /*
                        var testPlaylist = new YouTubePlayList("UClD2AKBeZz25QSKU2XmZX6w", apiKey, 1000).GetPlaylistData();
                        StringBuilder sb = new StringBuilder();
                        foreach(var playlist in testPlaylist)
                        {
                            sb.AppendLine($"{playlist.Title} -- {playlist.ID}");
                            
                        }
                        MessageBox.Show(sb.ToString());
                        */
                        
                        //var channelStr = channelInput.Text;
                        var playlistStr = playlistInput.Text;

                        //var playlistsOnChannel = new YouTubePlayList(channelStr, apiKey, 1000).GetPlaylistData();
                        //var playlist = new YouTubeVideo(playlistStr, apiKey, 1000).GetVideoData();
                        //var target_playlist_id = playlistsOnChannel.Where(a => a.ID.Contains(playlistStr) || a.Title.Contains(playlistStr)).FirstOrDefault().ID;

                        var playlist = new YouTubeVideo(playlistStr, apiKey, 1).GetVideoData();
                        if (playlist == null)
                        {
                            MessageBox.Show($"Playlist {playlistStr} is not valid. Please try again.");
                        }
                        else
                        {
                            ((PlaylistTypeSelectionWindow)prevWindow).CreateYoutubePlaylist(playlistStr, this);
                        }
                        

                    } catch (Exception e)
                    {   
                        MessageBox.Show($"Playlist {playlistInput.Text} s not valid. Please try again.");
                        Console.WriteLine(e);
                    }

                    break;
                default:
                    Console.WriteLine($"Unknown logic for playlist type {playlistType}. Closing.");
                    break;
        }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string apiKey { get; }

        public Window prevWindow { get; set; }
        public string playlistType { get; set; }

        private string _textInput = string.Empty;
        public string textInput { get { return _textInput; } set { _textInput = value; OnPropertyChanged(); } }
    }
}
