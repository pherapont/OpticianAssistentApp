using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignJournalLib
{
    interface IDesignLibraryManagable
    {
        List<DesignTask> GetDesignLibrary();
        void SaveDesignTask(DesignTask task);
    }
}
