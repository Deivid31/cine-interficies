// Updated by XamlIntelliSenseFileGenerator 18/11/2024 20:15:56
#pragma checksum "..\..\Cargar_Peliculas.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FDD62C4840739A8FFEE97566D1B64E3D317631362CB6FA4F0523416468F6FB94"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Peliculas;
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


namespace Peliculas
{


    /// <summary>
    /// Cargar_Peliculas
    /// </summary>
    public partial class Cargar_Peliculas : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 36 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid filmsGrid;

#line default
#line hidden


#line 49 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox genreBox;

#line default
#line hidden


#line 51 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox langBox;

#line default
#line hidden


#line 53 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker diaInBox;

#line default
#line hidden


#line 55 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox hourBox;

#line default
#line hidden


#line 56 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox minuteBox;

#line default
#line hidden


#line 57 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button confirmarButton;

#line default
#line hidden


#line 58 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cleanButton;

#line default
#line hidden


#line 59 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button añadir_Button;

#line default
#line hidden


#line 60 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button limpiarGen_Button;

#line default
#line hidden


#line 61 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label genres_Label;

#line default
#line hidden


#line 62 "..\..\Cargar_Peliculas.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Genres_TxtB;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Peliculas;component/cargar_peliculas.xaml", System.UriKind.Relative);

#line 1 "..\..\Cargar_Peliculas.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.filmsGrid = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 2:
                    this.genreBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 3:
                    this.langBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 4:
                    this.diaInBox = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 5:
                    this.hourBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 6:
                    this.minuteBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 7:
                    this.confirmarButton = ((System.Windows.Controls.Button)(target));

#line 57 "..\..\Cargar_Peliculas.xaml"
                    this.confirmarButton.Click += new System.Windows.RoutedEventHandler(this.confirmarButton_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.cleanButton = ((System.Windows.Controls.Button)(target));

#line 58 "..\..\Cargar_Peliculas.xaml"
                    this.cleanButton.Click += new System.Windows.RoutedEventHandler(this.cleanButton_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.añadir_Button = ((System.Windows.Controls.Button)(target));

#line 59 "..\..\Cargar_Peliculas.xaml"
                    this.añadir_Button.Click += new System.Windows.RoutedEventHandler(this.añadir_Button_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.limpiarGen_Button = ((System.Windows.Controls.Button)(target));

#line 60 "..\..\Cargar_Peliculas.xaml"
                    this.limpiarGen_Button.Click += new System.Windows.RoutedEventHandler(this.limpiarGen_Button_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.genres_Label = ((System.Windows.Controls.Label)(target));
                    return;
                case 12:
                    this.Genres_TxtB = ((System.Windows.Controls.TextBlock)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.ComboBox minuteBox_Copy;
    }
}

