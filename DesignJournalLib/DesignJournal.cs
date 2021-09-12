using System.IO;
using System.Collections.Generic;

namespace DesignJournalLib
{
    public class DesignJournal
    {
        List<DesignTask> designLibrary;
        DesignJournalToXML designJournalToXML;

        public DesignJournal(string storeDir)
        {
            designJournalToXML = new DesignJournalToXML(storeDir);

            if (File.Exists($"{storeDir}\\designJournal.xml"))
            {
                designLibrary = GetLibraryFromStorage();
            }
            else
            {
                designLibrary = new List<DesignTask>();
            }
        }

        public List<DesignTask> GetDesignLibrary()
        {
            return designLibrary;
        }

        public void SaveDesignTask(DesignTask task)
        {
            designLibrary.Add(task);

            designJournalToXML.SaveDesignTaskToXML(task);
        }

        private List<DesignTask> GetLibraryFromStorage()
        {
            return designJournalToXML.GetLibrary();
        }

    }
}
