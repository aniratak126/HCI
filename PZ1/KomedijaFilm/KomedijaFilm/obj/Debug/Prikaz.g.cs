﻿#pragma checksum "..\..\Prikaz.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "54FC747952C803DC9DE870751EFF5049BC121A5DC096138240AAEB824EADFAC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KomedijaFilm;
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


namespace KomedijaFilm {
    
    
    /// <summary>
    /// Prikaz
    /// </summary>
    public partial class Prikaz : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button IzlazBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label OpisLbl;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtbEditor;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Naziv;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProdKuca;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Trajanje;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Premijera;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image FilmImg;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Prikaz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ImageBrd;
        
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
            System.Uri resourceLocater = new System.Uri("/KomedijaFilm;component/prikaz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Prikaz.xaml"
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
            
            #line 8 "..\..\Prikaz.xaml"
            ((KomedijaFilm.Prikaz)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IzlazBtn = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\Prikaz.xaml"
            this.IzlazBtn.Click += new System.Windows.RoutedEventHandler(this.IzlazBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OpisLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.rtbEditor = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 5:
            this.Naziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ProdKuca = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Trajanje = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Premijera = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.FilmImg = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.ImageBrd = ((System.Windows.Controls.Border)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

