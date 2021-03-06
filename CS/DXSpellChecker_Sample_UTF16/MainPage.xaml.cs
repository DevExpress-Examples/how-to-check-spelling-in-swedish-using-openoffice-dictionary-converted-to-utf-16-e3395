using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.SpellChecker;
using System.IO;
using System.Reflection;
using DevExpress.XtraSpellChecker;
using System.Globalization;
using System.Text;

namespace DXSpellChecker_Sample_UTF16
{
    public partial class MainPage : UserControl
    {
        SpellChecker checker;
        public MainPage()
        {
            InitializeComponent();

            textEdit.Text = @"Hushåll är en enhet av människor som delar bostad och de kan även ansvara för varandras försörjning.
Ofta finns släktskap eller intima relationer inom ett hushåll. 
Så behöver dock inte vara fallet, utan även strikt rationella skäl kan ligga till grund för hushållsbildning.";

            checker = new SpellChecker();
            // Clear the dictionaries
            //checker.Dictionaries.Clear();
            // Get the Swedish dictionary and grammar from the assembly
            Stream dict = Assembly.GetExecutingAssembly().GetManifestResourceStream("DXSpellChecker_Sample_UTF16.sv_SE_utf16.dic");
            Stream grammar = Assembly.GetExecutingAssembly().GetManifestResourceStream("DXSpellChecker_Sample_UTF16.sv_SE_utf16.aff");
            // Create the dictionary
            SpellCheckerOpenOfficeDictionary dictionary = new SpellCheckerOpenOfficeDictionary();
            // Create the culture
            CultureInfo swedish = new CultureInfo("sv-SE");
            // Set dictionary culture
            dictionary.Culture = swedish; 
            // Set encoding to UTF-16 (Unicode)
            dictionary.Encoding = Encoding.Unicode;
            // Load the dictionary 
            // Note that culture and encoding settings should be specified before a dictionary is loaded
            dictionary.LoadFromStream(dict, grammar, null);
            // Add the dictionary to the collection
            checker.Dictionaries.Add(dictionary);
             
            // Set default culture of the spell checker
            checker.Culture = swedish;
        }

  
        private void Button_Click(object sender, RoutedEventArgs e)  {
            // Call the spell checker to inspect the text box.
            checker.Check(textEdit);
        }
    }
}
