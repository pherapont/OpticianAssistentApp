using System.Collections.Generic;

namespace DesignJournalLib
{
    interface IDesignJournal
    {
        List<DesignTask> Journal { get; }
        void SaveDesignTask(DesignTask task);
        List<DesignTask> GetJournalFromStorage();
    }
}
