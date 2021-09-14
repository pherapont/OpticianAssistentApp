using System.Windows;

namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSpherometrCalculator(object sender, RoutedEventArgs e)
        {
            SpherometrCalculator spherometrCalculator = new SpherometrCalculator();
            spherometrCalculator.Show();
        }

        private void OpenDesignJournal(object sender, RoutedEventArgs e)
        {
            DesignJournal designJournal = new DesignJournal();
            designJournal.Show();
        }
    }
}
