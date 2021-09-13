using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignJournalLib
{
    interface IDesignJournal
    {
        List<DesignTask> Journal { get; }
        void SaveDesignTask(DesignTask task);
        List<DesignTask> GetJournalFromStorage();
    }
}
