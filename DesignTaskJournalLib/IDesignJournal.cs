using System.Collections.Generic;

namespace DesignTaskJournalLib
{
    interface IDesignJournal
    {
        void SaveDesignTask(DesignTask task);
        (List<DesignTask>, List<DesignTask>, List<DesignTask>) GetJournalsFromStorage();
    }
}
