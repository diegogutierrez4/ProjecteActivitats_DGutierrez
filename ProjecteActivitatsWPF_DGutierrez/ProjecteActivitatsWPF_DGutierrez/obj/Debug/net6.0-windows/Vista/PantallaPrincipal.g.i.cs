﻿#pragma checksum "..\..\..\..\Vista\PantallaPrincipal.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1423A95FBBE86B8434E39B4BF24E1EEACA5B691F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjecteActivitatsWPF_DGutierrez.Vista;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjecteActivitatsWPF_DGutierrez.Vista {
    
    
    /// <summary>
    /// PantallaPrincipal
    /// </summary>
    public partial class PantallaPrincipal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\Vista\PantallaPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_TornarIniciSessio;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Vista\PantallaPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_AfegirActivitat;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Vista\PantallaPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonMinimitzar;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Vista\PantallaPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonSortir;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjecteActivitatsWPF_DGutierrez;V1.0.0.0;component/vista/pantallaprincipal.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vista\PantallaPrincipal.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.button_TornarIniciSessio = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\Vista\PantallaPrincipal.xaml"
            this.button_TornarIniciSessio.Click += new System.Windows.RoutedEventHandler(this.button_TornarIniciSessio_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.button_AfegirActivitat = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Vista\PantallaPrincipal.xaml"
            this.button_AfegirActivitat.Click += new System.Windows.RoutedEventHandler(this.button_AfegirActivitat_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonMinimitzar = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\Vista\PantallaPrincipal.xaml"
            this.buttonMinimitzar.Click += new System.Windows.RoutedEventHandler(this.buttonMinimitzarClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonSortir = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\Vista\PantallaPrincipal.xaml"
            this.buttonSortir.Click += new System.Windows.RoutedEventHandler(this.buttonSortirClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
