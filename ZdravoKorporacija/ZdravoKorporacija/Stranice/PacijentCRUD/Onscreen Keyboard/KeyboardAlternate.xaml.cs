using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZdravoKorporacija.Stranice.PacijentCRUD.Onscreen_Keyboard
{
    /// <summary>
    /// Interaction logic for KeyboardAlternate.xaml
    /// </summary>
    public partial class KeyboardAlternate : Window
    {
        private TextBox textBox;
        private Button button;
        public KeyboardAlternate(TextBox textCurrentBox, Button pressedButton)
        {
            InitializeComponent();
            textBox = textCurrentBox;
            button = pressedButton;
        }

        private void exclamationMark_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '!';
        }

        private void monkey_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '@';
        }

        private void hashtag_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '#';
        }

        private void dollar_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '$';
        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '%';
        }

        private void cap_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '^';
        }

        private void star_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '*';
        }

        private void leftParenth_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '(';
        }

        private void rightParenth_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ')';
        }

        private void underscore_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '_';
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '+';
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '-';
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '=';
        }

        private void squareLeftBracket_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '[';
        }

        private void squareRightBracket_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ']';
        }

        private void colon_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ':';
        }

        private void semicolon_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ';';
        }

        private void backslash_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '\\';
        }

        private void verticalBar_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '|';
        }

        private void questionMark_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '?';
        }

        private void greaterThan_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '>';
        }

        private void slash_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '/';
        }

        private void backtick_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '`';
        }

        private void tilde_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '~';
        }

        private void leftMark_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '«';
        }

        private void rightMark_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '»';
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }

        private void Space_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ' ';
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += ',';
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '.';
        }

        private void SpecialSigns_Click(object sender, RoutedEventArgs e)
        {
            Keyboard keyboard = new Keyboard(textBox, button);
            keyboard.Top = this.Top;
            keyboard.Left = this.Left;
            keyboard.ShowDialog();
            this.Close();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            button.Background = Brushes.White;
            Close();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '1';
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '2';
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '3';
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '4';
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '5';
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '6';
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '7';
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '8';
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '9';
        }

        private void b0_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += '0';
        }
    }

}
