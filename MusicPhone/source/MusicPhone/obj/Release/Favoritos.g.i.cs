﻿#pragma checksum "G:\Arquivos\Projetos\MusicPhone\MusicPhone\source\MusicPhone\Favoritos.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5C7BD87612B6E60AEC41EEACA19A0B4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
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
    
    
    public partial class Favoritos : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel Title;
        
        internal System.Windows.Controls.Image imgMusic;
        
        internal System.Windows.Controls.TextBlock txblTitlo;
        
        internal Microsoft.Phone.Controls.Panorama prmDetalhes;
        
        internal System.Windows.Controls.TextBlock tltNomeArtista;
        
        internal System.Windows.Controls.Grid grdMusic;
        
        internal System.Windows.Controls.ListBox lstMusic;
        
        internal Microsoft.Phone.Controls.PanoramaItem pnIDiscografia;
        
        internal System.Windows.Controls.Grid grdDiscografia;
        
        internal System.Windows.Controls.ListBox lstAlbuns;
        
        internal System.Windows.Controls.ListBox lstAtistRelated;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/MusicPhone;component/Favoritos.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.Title = ((System.Windows.Controls.StackPanel)(this.FindName("Title")));
            this.imgMusic = ((System.Windows.Controls.Image)(this.FindName("imgMusic")));
            this.txblTitlo = ((System.Windows.Controls.TextBlock)(this.FindName("txblTitlo")));
            this.prmDetalhes = ((Microsoft.Phone.Controls.Panorama)(this.FindName("prmDetalhes")));
            this.tltNomeArtista = ((System.Windows.Controls.TextBlock)(this.FindName("tltNomeArtista")));
            this.grdMusic = ((System.Windows.Controls.Grid)(this.FindName("grdMusic")));
            this.lstMusic = ((System.Windows.Controls.ListBox)(this.FindName("lstMusic")));
            this.pnIDiscografia = ((Microsoft.Phone.Controls.PanoramaItem)(this.FindName("pnIDiscografia")));
            this.grdDiscografia = ((System.Windows.Controls.Grid)(this.FindName("grdDiscografia")));
            this.lstAlbuns = ((System.Windows.Controls.ListBox)(this.FindName("lstAlbuns")));
            this.lstAtistRelated = ((System.Windows.Controls.ListBox)(this.FindName("lstAtistRelated")));
        }
    }
}

