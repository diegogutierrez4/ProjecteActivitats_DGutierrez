﻿#pragma checksum "..\..\..\..\Vista\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4626D87BAFA6756C3ABC3180B8C396054605FA7E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\..\Vista\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRegistre;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Vista\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_NomUsuari;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Vista\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox_Contrasenya;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Vista\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonIniciarSessio;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Vista\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonMinimitzar;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Vista\MainWindow.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ProjecteActivitatsWPF_DGutierrez;component/vista/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vista\MainWindow.xaml"
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
            this.buttonRegistre = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Vista\MainWindow.xaml"
            this.buttonRegistre.Click += new System.Windows.RoutedEventHandler(this.buttonRegistre_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 49 "..\..\..\..\Vista\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 53 "..\..\..\..\Vista\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBox_NomUsuari = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\..\Vista\MainWindow.xaml"
            this.textBox_NomUsuari.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBox_NomUsuari_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passwordBox_Contrasenya = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 84 "..\..\..\..\Vista\MainWindow.xaml"
            this.passwordBox_Contrasenya.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordBox_Contrasenya_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.buttonIniciarSessio = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\Vista\MainWindow.xaml"
            this.buttonIniciarSessio.Click += new System.Windows.RoutedEventHandler(this.buttonIniciarSessio_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.buttonMinimitzar = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\Vista\MainWindow.xaml"
            this.buttonMinimitzar.Click += new System.Windows.RoutedEventHandler(this.buttonMinimitzarClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.buttonSortir = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\Vista\MainWindow.xaml"
            this.buttonSortir.Click += new System.Windows.RoutedEventHandler(this.buttonSortirClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

