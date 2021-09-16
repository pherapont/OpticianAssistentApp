using System.Windows;


namespace OpticianAssistentUI
{
    /// <summary>
    /// Interaction logic for DesignTaskCreate.xaml
    /// </summary>
    public partial class DesignTaskCreate : Window
    {
        DesignJournalController journalController;

        public DesignTaskCreate(DesignJournalController controller)
        {
            InitializeComponent();

            journalController = controller;
        }

        private void newTaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = newTaskName.Text;
            string taskContent = newTaskContent.Text;

            journalController.CreateNewTask(taskName, taskContent);

            this.Close();
        }
    }
}
