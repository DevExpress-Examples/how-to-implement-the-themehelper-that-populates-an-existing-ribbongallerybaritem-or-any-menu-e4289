Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Bars
Imports System.Windows.Media.Imaging
Imports System.Windows.Media

Namespace RibbonControl_Ex
	Public NotInheritable Class ThemeHelper
		Private Sub New()
		End Sub
		Public Shared Sub InitThemeSubItems(ByVal barSubTheme As BarSubItem)
			InitThemeSubItems(barSubTheme, True)
		End Sub
        Public Shared Sub InitThemeSubItems(ByVal barSubTheme As BarSubItem, ByVal _UseLargeIcon As Boolean)
            For Each theme As Theme In theme.Themes
                Dim item As New BarButtonItem() With {.Content = theme.Name, .Glyph = LoadImageByThemeName(theme.Name, _UseLargeIcon)}
                AddHandler item.ItemClick, AddressOf item_ItemClick
                barSubTheme.ItemLinks.Add(item)
            Next theme
        End Sub
		Public Shared Sub InitThemeGallery(ByVal galleryBarItem As RibbonGalleryBarItem)
			InitThemeGallery(galleryBarItem, True)
		End Sub
        Public Shared Sub InitThemeGallery(ByVal galleryBarItem As RibbonGalleryBarItem, ByVal _UseLargeIcon As Boolean)
            InitThemeGallery(galleryBarItem.Gallery, _UseLargeIcon)
        End Sub
        Public Shared Sub InitThemeGallery(ByVal _gallery As Gallery)
            InitThemeGallery(_gallery, True)
        End Sub
        Public Shared Sub InitThemeGallery(ByVal _gallery As Gallery, ByVal _UseLargeIcon As Boolean)
            AddHandler _gallery.ItemClick, AddressOf Gallery_ItemClick
            For Each theme As Theme In theme.Themes
                _gallery.Groups(0).Items.Add(New GalleryItem() With {.Caption = theme.Name, .Glyph = LoadImageByThemeName(theme.Name, _UseLargeIcon)})
            Next theme
        End Sub
		Private Shared Sub Gallery_ItemClick(ByVal sender As Object, ByVal e As GalleryItemEventArgs)
			ThemeManager.ApplicationThemeName = e.Item.Caption.ToString()
		End Sub
		Private Shared Sub item_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			ThemeManager.ApplicationThemeName = e.Item.Content.ToString()
		End Sub
		Private Shared Function LoadImageByThemeName(ByVal name As String, ByVal _UseLargeIcon As Boolean) As ImageSource
			Dim fileName As String = Nothing
			If _UseLargeIcon Then
				fileName = name
			Else
				fileName = name & "_24x24"
			End If
			Return New BitmapImage(New Uri("Images/" & fileName & ".png", UriKind.Relative))
		End Function
	End Class
End Namespace
