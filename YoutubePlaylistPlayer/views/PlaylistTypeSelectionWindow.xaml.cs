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
using System.Windows.Shapes;

namespace YoutubePlaylistPlayer.views
{
    /// <summary>
    /// Interaction logic for PlaylistTypeSelectionWindow.xaml
    /// </summary>
    public partial class PlaylistTypeSelectionWindow : Window
    {
        public PlaylistTypeSelectionWindow(Window mainWindow, string apiKey)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            this.apiKey = apiKey;
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = ((Button)sender).Tag.ToString();
            var window = new PlaylistInputWindow(this, button, apiKey);
            window.Show();
        }

        public void CreateYoutubePlaylist(string id, Window prevWindow)
        {
            prevWindow.Close();
            ((MainWindow)mainWindow).CreateYoutubePlaylist(id, this);
        }

        public string apiKey { get; }
        public Window mainWindow { get; set; }

    }
}
