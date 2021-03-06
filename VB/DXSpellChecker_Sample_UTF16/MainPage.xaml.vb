Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.SpellChecker
Imports System.IO
Imports System.Reflection
Imports DevExpress.XtraSpellChecker
Imports System.Globalization
Imports System.Text

Namespace DXSpellChecker_Sample_UTF16
	Partial Public Class MainPage
		Inherits UserControl
		Private checker As SpellChecker
		Public Sub New()
			InitializeComponent()

			textEdit.Text = "Hushåll är en enhet av människor som delar bostad och de kan även ansvara för varandras försörjning." & ControlChars.CrLf & "Ofta finns släktskap eller intima relationer inom ett hushåll. " & ControlChars.CrLf & "Så behöver dock inte vara fallet, utan även strikt rationella skäl kan ligga till grund för hushållsbildning."

			checker = New SpellChecker()
			' Clear the dictionaries
			'checker.Dictionaries.Clear();
			' Get the Swedish dictionary and grammar from the assembly
			Dim dict As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("sv_SE_utf16.dic")
			Dim grammar As Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("sv_SE_utf16.aff")
			' Create the dictionary
			Dim dictionary As New SpellCheckerOpenOfficeDictionary()
			' Create the culture
			Dim swedish As New CultureInfo("sv-SE")
			' Set dictionary culture
			dictionary.Culture = swedish
			' Set encoding to UTF-16 (Unicode)
			dictionary.Encoding = Encoding.Unicode
			' Load the dictionary 
			' Note that culture and encoding settings should be specified before a dictionary is loaded
			dictionary.LoadFromStream(dict, grammar, Nothing)
			' Add the dictionary to the collection
			checker.Dictionaries.Add(dictionary)

			' Set default culture of the spell checker
			checker.Culture = swedish
		End Sub


		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Call the spell checker to inspect the text box.
			checker.Check(textEdit)
		End Sub
	End Class
End Namespace
