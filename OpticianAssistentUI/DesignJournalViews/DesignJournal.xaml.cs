using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpticianAssistentUI
{
    public partial class DesignJournal : Window
    {
        DesignJournalController journalController;

        // TODO передавать адрес папки журнала из пользовательского интерфейса
        public DesignJournal()
        {
            InitializeComponent();

            journalController = new DesignJournalController(@"C:\");

            FillJournalLayout();
        }

        private void CreateDesignTask_Click(object sender, RoutedEventArgs e)
        {
            DesignTaskCreate taskCreationWindow = new DesignTaskCreate(journalController, GetTaskPriority());

            taskCreationWindow.Show();
        }

        private void OnJournalCellClick(object sender, RoutedEventArgs e)
        {
            DesignTaskRead dtr = new DesignTaskRead();
            dtr.Show();
        }

        private void FillJournalLayout()
        {
            List<DesignTaskData> designTasks = journalController.GetJournalData(GetTaskPriority());

            for (int i = 0; i < designTasks.Count; i++)
            {
                TextBlock textBlock = (TextBlock)LowJournalLayout.Children[i];
                textBlock.Text = designTasks[i].Name;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Style = (Style)TryFindResource("StyleJournalCell");
                textBlock.MouseLeftButtonDown += new MouseButtonEventHandler(OnJournalCellClick);
            }

        }
        private TaskPriority GetTaskPriority()
        {
            return TabHighPriority.IsSelected ? TaskPriority.Heigh : TabMiddlePriority.IsSelected ? TaskPriority.Middle : TaskPriority.Low;
        }
    }
}
