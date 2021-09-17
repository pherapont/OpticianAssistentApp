using System.Windows;


namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for DesignTaskCreate.xaml
    /// </summary>
    public partial class DesignTaskCreate : Window
    {
        DesignJournalController journalController;
        TaskPriority taskPriority;

        internal DesignTaskCreate(DesignJournalController controller, TaskPriority priority)
        {
            InitializeComponent();

            journalController = controller;
            taskPriority = priority;
        }

        private void newTaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = newTaskName.Text;
            string taskContent = newTaskContent.Text;

            journalController.CreateNewTask(taskName, taskContent, taskPriority);

            this.Close();
        }
    }
}
