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
using SpherometrCalcLib;

namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for SpherometrCalculator.xaml
    /// </summary>
    public partial class SpherometrCalculator : Window
    {
        public SpherometrCalculator()
        {
            InitializeComponent();
        }

        private void CalculateSpheraParametrs(object sender, RoutedEventArgs e)
        {
            message.Text = "Hello, world!";
        }
    }
}
