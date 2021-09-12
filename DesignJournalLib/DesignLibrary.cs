using System.IO;
using System.Collections.Generic;

namespace DesignJournalLib
{
    public class DesignLibrary
    {
        List<DesignTask> designLibrary;
        DesignLibraryToXML designLibraryToXML;

        public DesignLibrary(string storeDir)
        {
            DesignLibraryToXML designLibraryToXML = new DesignLibraryToXML(storeDir);

            if (File.Exists($"{storeDir}\\designLibrary.xml"))
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

            designLibraryToXML.SaveDesignTaskToXML(task);
        }

        private List<DesignTask> GetLibraryFromStorage()
        {
            return designLibraryToXML.GetLibrary();
        }

    }
}
