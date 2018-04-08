using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Bars;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace RibbonControl_Ex
{
    public static class ThemeHelper
    {
        public static void InitThemeSubItems(BarSubItem barSubTheme)
        {
            InitThemeSubItems(barSubTheme, true);
        }
        public static void InitThemeSubItems(BarSubItem barSubTheme, bool _UseLargeIcon = true)
        {
            foreach (Theme theme in Theme.Themes)
            {
                BarButtonItem item = new BarButtonItem()
                {
                    Content = theme.Name,
                    Glyph = LoadImageByThemeName(theme.Name, _UseLargeIcon),
                };
                item.ItemClick += new ItemClickEventHandler(item_ItemClick);
                barSubTheme.ItemLinks.Add(item);
            }
        }
        public static void InitThemeGallery(RibbonGalleryBarItem galleryBarItem)
        {
            InitThemeGallery(galleryBarItem, true);
        }
        public static void InitThemeGallery(RibbonGalleryBarItem galleryBarItem, bool _UseLargeIcon = true)
        {
            InitThemeGallery(galleryBarItem.Gallery, _UseLargeIcon);
        }
        public static void InitThemeGallery(Gallery gallery)
        {
            InitThemeGallery(gallery, true);
        }
        public static void InitThemeGallery(Gallery _gallery, bool _UseLargeIcon = true)
        {
            _gallery.ItemClick += new GalleryItemEventHandler(Gallery_ItemClick);
            foreach (Theme theme in Theme.Themes)
            {
                _gallery.Groups[0].Items.Add(new GalleryItem()
                {
                    Caption = theme.Name,
                    Glyph = LoadImageByThemeName(theme.Name, _UseLargeIcon)
                });
            }
        }
        static void Gallery_ItemClick(object sender, GalleryItemEventArgs e)
        {
            ThemeManager.ApplicationThemeName = e.Item.Caption.ToString();
        }
        static void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemeManager.ApplicationThemeName = e.Item.Content.ToString();
        }
        private static ImageSource LoadImageByThemeName(string name, bool _UseLargeIcon)
        {
            string fileName = null;
            if (_UseLargeIcon)
            {
                fileName = name;
            }
            else
            {
                fileName = name + "_24x24";
            }
            return new BitmapImage(new Uri("Images/" + fileName + ".png", UriKind.Relative));
        }
    }
}
