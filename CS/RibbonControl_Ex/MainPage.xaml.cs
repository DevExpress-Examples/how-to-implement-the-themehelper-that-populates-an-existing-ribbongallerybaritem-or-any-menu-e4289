using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace RibbonControl_Ex {
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            ThemeHelper.InitThemeGallery(gRibbonThemeGalleryBarItem);
            ThemeHelper.InitThemeGallery(ThemeDropDownGallery);
            ThemeHelper.InitThemeSubItems(ThemeGalleryBarSubItem);
        }
    }
}
