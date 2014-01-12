using EnvironmentVariablesWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnvironmentVariablesWPF
{
    /// <summary>
    /// Logique d'interaction pour EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        /// <summary>
        /// Char who use to split text in Value Box.
        /// </summary>
        private char separator = '\0';

        #region Getter/Setter
        public new string Name { get { return NameBox.Text; } }
        public string Value { get { return ValueBox.Text.Replace("\n",""); } }
        #endregion

        /// <summary>
        /// Default constructor, to add new environment variable.
        /// </summary>
        public EditWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor, to edit environment variable
        /// </summary>
        /// <param name="name">Variable's name</param>
        /// <param name="value">Variable's value</param>
        public EditWindow(string name, string  value)
        {
            InitializeComponent();
            NameBox.Text = name;
            ValueBox.Text = value;
        }

        /// <summary>
        /// Click on valid button, the user accept the modifications in environment variable.
        /// </summary>
        private void Valid_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Click on valid button, the user cancel the modifications in environment variable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        /// <summary>
        /// The separator text box can containt one character max. 
        /// Enter a character split string of value in some text boxs.
        /// If the text box is empty, value is displayed in one text box.
        /// </summary>
        private void Separator_TextChanged(object sender, TextChangedEventArgs e)
        {
            var SeparatorBox = sender as TextBox;
            if (SeparatorBox != null)
            {
                if (!String.IsNullOrEmpty(SeparatorBox.Text))
                {
                    separator = SeparatorBox.Text.Last(); ;
                    SeparatorBox.Text = ""+separator;
                }
                else
                {
                    separator = '\0';
                    ValueBox.Text = ValueBox.Text.Replace("\n","");
                }
            }
            AdapterText();
        }

        /// <summary>
        /// When text in Value box is modified. 
        /// If separator char is added, add also linebreak.
        /// If separator char is removed, remove also linebreak.
        /// </summary>
        private void ValueBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AdapterText();
        }

        /// <summary>
        /// Modify the text to split up text value box.
        /// If need, the cursor is moved.
        /// </summary>
        private void AdapterText()
        {
            if (separator == '\0')
                return;
            string tmpText = ValueBox.Text;
            int offset = ValueBox.CaretIndex;
            for (int i = 0; i < tmpText.Count(); i++)
            {
                char tmpChar = tmpText[i];
                //If tmpChar is separator, check next char is linebreak, else add linebreak.
                if (tmpChar == separator)
                {
                    //If Separator char is last char in Text, add linebreak.
                    if (i + 1 == tmpText.Count())
                    {
                        tmpText += '\n';
                        offset++;
                    }
                    //If next char is not linebreak, insert linebreak 
                    else if (tmpText[i + 1] != '\n')
                    {
                        tmpText = tmpText.Insert(i + 1, "" + '\n');
                        offset++;
                    }
                }
                //If tmpChar is linebreak, check if precedent char is seprator, else remove that linebreak.
                if (tmpChar == '\n')
                {
                    //If linebreak is first character or
                    //If precedent char is not separator , then remove linebreak.
                    if (i == 0 || tmpText[i - 1] != separator)
                    {
                        tmpText = tmpText.Remove(i,1);
                        i--; //Because, we check i char again.
                    }
                }
            }
            //Accept the modification in ValueBox.
            ValueBox.Text = tmpText;
            ValueBox.CaretIndex = offset;
        }
    }
}
