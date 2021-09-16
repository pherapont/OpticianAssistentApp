using DesignTaskJournalLib;
using System;

namespace OpticianAssistentUI
{
    public class DesignJournalController
    {
        DesignJournalXML journalXML;

        public DesignJournalController(string storeDir)
        {
            journalXML = new DesignJournalXML(storeDir);
        }

        internal void CreateNewTask(string taskName, string taskContent)
        {
            DesignTask task = new DesignTask
            {
                Name = taskName,
                Content = taskContent,
                CreationTime = DateTime.Now
            };

            journalXML.SaveDesignTask(task);
        }
    }
}
