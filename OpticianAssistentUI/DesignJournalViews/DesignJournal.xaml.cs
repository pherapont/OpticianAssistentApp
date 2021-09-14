﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                TextBlock textBlock = (TextBlock)LowJournalLayout.Children[i];
                textBlock.Text = designTasks[i].DTName;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Style = (Style)TryFindResource("StyleJournalCell");
                textBlock.MouseLeftButtonDown += new MouseButtonEventHandler(OnJournalCellClick);
            }

        }

        private void OnJournalCellClick(object sender, RoutedEventArgs e)
        {
            DesignTaskRead dtr = new DesignTaskRead();
            dtr.Show();
        }

        // TODO В этом методе будем подключать библиотеку DesingJournalLib
        private List<DesignTask> GetDesignTasks()
        {
            List<DesignTask> designTasks = new List<DesignTask>();

            designTasks.Add(new DesignTask { DTName = "Отказ от унификации угла отражения" });
            designTasks.Add(new DesignTask { DTName = "Согласование изменений" });
            designTasks.Add(new DesignTask { DTName = "Уточнение конструкции приемника" });

            return designTasks;
        }
    }
}