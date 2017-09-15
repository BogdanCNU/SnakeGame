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

namespace SnakeGameUI
{
    /// <summary>
    /// Interaction logic for InsertPlayerNameWindow.xaml
    /// </summary>
    public partial class InsertPlayerNameWindow : Window
    {
        public string PlayerName
        {
            get;
            set;
        }

        public InsertPlayerNameWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerName = UsernameTextBox.Text;
            this.Close();
        }
    }
}
