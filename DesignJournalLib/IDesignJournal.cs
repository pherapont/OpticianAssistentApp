using System.Collections.Generic;

namespace DesignJournalLib
{
    interface IDesignJournal
    {
        void SaveDesignTask(DesignTask task);
        (List<DesignTask>, List<DesignTask>, List<DesignTask>) GetJournalsFromStorage();
    }
}
