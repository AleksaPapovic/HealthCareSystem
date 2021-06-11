using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ZdravoKorporacija.Stranice.PacijentCRUD.Onscreen_Keyboard
{

    public partial class Keyboard : Window
    {
        private bool shiftPressed = true;
        private Button button;
        private TextBox textBox;
        public Keyboard(TextBox currentTextBox, Button pressedButton)
        {
            InitializeComponent();
            textBox = currentTextBox;
            button = pressedButton;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Q_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) 
            { 
                textBox.Text += 'Q';
            }
            else
            {
                textBox.Text += 'q';
            }
        }

        private void W_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed)
            {
                textBox.Text += 'W';
            }
            else
            {
                textBox.Text += 'w';
            }
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'E';
            else
            {
                textBox.Text += 'e';
            }
        }

        private void R_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'R';
            else
            {
                textBox.Text += 'r';
            }
        }

        private void T_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'T';
            else
            {
                textBox.Text += 't';
            }
        }

        private void Z_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'Z';
            else
            {
                textBox.Text += 'z';
            }
        }

        private void U_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'U';
            else
            {
                textBox.Text += 'u';
            }
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'I';
            else
            {
                textBox.Text += 'i';
            }
        }

        private void O_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'O';
            else
            {
                textBox.Text += 'o';
            }
        }

        private void P_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'P';
            else
            {
                textBox.Text += 'p';
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'A';
            else
            {
                textBox.Text += 'a';
            }
        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'S';
            else
            {
                textBox.Text += 's';
            }
        }

        private void D_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'D';
            else
            {
                textBox.Text += 'd';
            }
        }

        private void F_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'F';
            else
            {
                textBox.Text += 'f';
            }
        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'G';
            else
            {
                textBox.Text += 'g';
            }

        }

        private void H_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'H';
            else
            {
                textBox.Text += 'h';
            }
        }

        private void J_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'J';
            else
            {
                textBox.Text += 'j';
            }
        }

        private void K_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'K';
            else
            {
                textBox.Text += 'k';
            }
        }

        private void L_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'L';
            else
            {
                textBox.Text += 'l';
            }
        }

        private void Y_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'Y';
            else
            {
                textBox.Text += 'y';
            }
        }

        private void X_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'X';
            else
            {
                textBox.Text += 'x';
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'C';
            else
            {
                textBox.Text += 'c';
            }
        }

        private void V_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'V';
            else
            {
                textBox.Text += 'v';
            }
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'B';
            else
            {
                textBox.Text += 'b';
            }
        }

        private void N_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'N';
            else
            {
                textBox.Text += 'n';
            }
        }

        private void M_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed) textBox.Text += 'M';
            else
            {
                textBox.Text += 'm';
            }
        }

        private void Shift_Click(object sender, RoutedEventArgs e)
        {
            if (shiftPressed)
            {
                Shift.Background = Brushes.White;
                shiftPressed = false;
            }
            else
            {
                Shift.Background = Brushes.CornflowerBlue;
                shiftPressed = true;
            }
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
            KeyboardAlternate keyboardAlternate = new KeyboardAlternate(textBox, button);
            keyboardAlternate.Top = this.Top;
            keyboardAlternate.Left = this.Left;
            keyboardAlternate.ShowDialog();
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
