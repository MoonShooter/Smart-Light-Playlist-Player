#pragma checksum "..\..\..\views\PlaylistDisplayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F20F43B631BDBA347DD5F58D704BF0AFDDB2278E237ECD060BE8775513ACB208"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using YoutubePlaylistPlayer.views;


namespace YoutubePlaylistPlayer.views {
    
    
    /// <summary>
    /// PlaylistDisplayWindow
    /// </summary>
    public partial class PlaylistDisplayWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView videosList;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ytplv_ImageSource;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ytplv_Name;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ytplv_VideoLength;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ytplv_ScriptInstructions;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\views\PlaylistDisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridViewColumn ytplv_IgnoreVideo;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/YoutubePlaylistPlayer;component/views/playlistdisplaywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\views\PlaylistDisplayWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.videosList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.ytplv_ImageSource = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 3:
            this.ytplv_Name = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 4:
            this.ytplv_VideoLength = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 5:
            this.ytplv_ScriptInstructions = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 6:
            this.ytplv_IgnoreVideo = ((System.Windows.Controls.GridViewColumn)(target));
            return;
            case 7:
            
            #line 77 "..\..\..\views\PlaylistDisplayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OK_Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 83 "..\..\..\views\PlaylistDisplayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

