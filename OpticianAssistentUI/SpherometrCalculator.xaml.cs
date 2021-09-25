using System.Windows;
using System.Windows.Controls;
using SpheroLib;

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

        private void SpherometrType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)spherometrType.SelectedItem;
            if (selectedItem == big)
            {
                if(bigRings != null)
                    bigRings.IsEnabled = true;
                if (smallRings != null)
                    smallRings.IsEnabled = false;
            }
            else
            {
                if (bigRings != null)
                    bigRings.IsEnabled = false;
                if (smallRings != null)
                    smallRings.IsEnabled = true;
            }
        }
    }
}
