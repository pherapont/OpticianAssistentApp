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

namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for DesignJournal.xaml
    /// </summary>
    public partial class DesignJournal : Window
    {
        public DesignJournal()
        {
            InitializeComponent();

            FillJournalLayout();
        }

        private void FillJournalLayout()
        {
            List<DesignTask> designTasks = GetDesignTasks();

            for (int i = 0; i < designTasks.Count; i++)
            {
                TextBlock textBlock = (TextBlock)JournalLayout.Children[i];
                textBlock.Text = designTasks[i].DTName;
                textBlock.FontSize = 18;
                textBlock.FontFamily = new FontFamily("Arial");
                textBlock.FontWeight = FontWeights.Bold;
                textBlock.FontStyle = FontStyles.Italic;
                textBlock.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.TextWrapping = TextWrapping.Wrap;
            }
            
        }

        List<DesignTask> GetDesignTasks()
        {
            List<DesignTask> designTasks = new List<DesignTask>();

            designTasks.Add(new DesignTask { DTName = "Отказ от унификации угла отражения" });
            designTasks.Add(new DesignTask { DTName = "Согласование изменений" });
            designTasks.Add(new DesignTask { DTName = "Уточнение конструкции приемника" });

            return designTasks;
        }
    }
}
