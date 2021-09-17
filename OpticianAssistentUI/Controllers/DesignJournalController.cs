using DesignTaskJournalLib;
using System;
using System.Collections.Generic;

namespace OpticianAssistentUI
{
    public class DesignJournalController
    {
        private DesignJournalXML journalXML;
        private (List<DesignTask>, List<DesignTask>, List<DesignTask>) designTasksTuple;

        public DesignJournalController(string storeDir)
        {
            journalXML = new DesignJournalXML(storeDir);
            designTasksTuple = journalXML.GetJournalsFromStorage();
        }

        internal void CreateNewTask(string taskName, string taskContent, TaskPriority taskPriority)
        {
            DesignTask task = new DesignTask
            {
                Name = taskName,
                Content = taskContent,
                CreationTime = DateTime.Now
            };

            DesignTaskPriority priority;

            switch (taskPriority)
            {
                case TaskPriority.Heigh:
                    {
                        priority = DesignTaskPriority.High;
                        break;
                    }
                case TaskPriority.Middle:
                    {
                        priority = DesignTaskPriority.Middle;
                        break;
                    }
                default:
                    {
                        priority = DesignTaskPriority.Low;
                        break;
                    }
            }

            task.Priority = priority;

            journalXML.SaveDesignTask(task);
        }

        // Доставить список задач в окно 
        internal List<DesignTaskData> GetJournalData(TaskPriority taskPriority)
        {
            List<DesignTask> designTasks;
            List<DesignTaskData> taskDataList = new List<DesignTaskData>();

            switch (taskPriority)
            {
                case TaskPriority.Low:
                    {
                        designTasks = designTasksTuple.Item1;
                        break;
                    }
                case TaskPriority.Middle:
                    {
                        designTasks = designTasksTuple.Item2;
                        break;
                    }
                default:
                    {
                        designTasks = designTasksTuple.Item3;
                        break;
                    }
            }
            foreach (DesignTask task in designTasks)
            {
                DesignTaskData taskData = new DesignTaskData
                {
                    Name = task.Name,
                    Content = task.Content,
                    Priority = taskPriority,
                    CreationTime = task.CreationTime,
                    UpdateTime = task.UpdateTime
                };
                taskDataList.Add(taskData);
            }
            return taskDataList;            
        }
    }
}
