﻿#pragma checksum "C:\Users\m.nunes.abrantes\Documents\Visual Studio 2013\Projects\MusicPhone\MusicPhone\source\MusicPhone\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4B5F5852EDCB2178B2C900A6184ED948"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace MusicPhone {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Image imgMusic;
        
        internal System.Windows.Controls.TextBlock txblTitlo;
        
        internal System.Windows.Controls.TextBox txblNomeMusic;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid grdAvaliacaoNet;
        
        internal Microsoft.Phone.Shell.ApplicationBar appbarPrincipal;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/MusicPhone;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.imgMusic = ((System.Windows.Controls.Image)(this.FindName("imgMusic")));
            this.txblTitlo = ((System.Windows.Controls.TextBlock)(this.FindName("txblTitlo")));
            this.txblNomeMusic = ((System.Windows.Controls.TextBox)(this.FindName("txblNomeMusic")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.grdAvaliacaoNet = ((System.Windows.Controls.Grid)(this.FindName("grdAvaliacaoNet")));
            this.appbarPrincipal = ((Microsoft.Phone.Shell.ApplicationBar)(this.FindName("appbarPrincipal")));
        }
    }
}

