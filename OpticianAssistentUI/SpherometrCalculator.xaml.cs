using System.Collections.Generic;
using System.Windows;
using SpheroLib;

namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for SpherometrCalculator.xaml
    /// </summary>
    public partial class SpherometrCalculator : Window
    {
        SpherometrWindowContext windowContext;
        public SpherometrCalculator()
        {
            InitializeComponent();

            windowContext = new SpherometrWindowContext
            {
                BigRings = new List<BigRingsData>(),
                SmallRings = new List<SmallRingsData>()
            };

            // TODO Вынести добавление новых элементов в windowContext в отдельный метод, который будет формировать этот контекст в зависимости от типа калькулятора

            windowContext.BigRings.Add(new BigRingsData { Text = "Кольцо 1", RingBig = RingsOfBigSpherometr.Ring1 });
            windowContext.BigRings.Add(new BigRingsData { Text = "Кольцо 2", RingBig = RingsOfBigSpherometr.Ring2 });

            windowContext.SmallRings.Add(new SmallRingsData { Text = "Кольцо 1", RingSmall = RingsOfSmallSpherometr.Ring1 });
            windowContext.SmallRings.Add(new SmallRingsData { Text = "Кольцо 2", RingSmall = RingsOfSmallSpherometr.Ring2 });

            this.DataContext = windowContext;
        }

        private void CalculateSpheraParametrs(object sender, RoutedEventArgs e)
        {

        }
    }
}
