Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Controls

Namespace RibbonControl_Ex
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			ThemeHelper.InitThemeGallery(gRibbonThemeGalleryBarItem)
			ThemeHelper.InitThemeGallery(ThemeDropDownGallery)
			ThemeHelper.InitThemeSubItems(ThemeGalleryBarSubItem)
		End Sub
	End Class
End Namespace
