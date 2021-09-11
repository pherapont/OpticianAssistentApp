using System;

namespace DesignJournalLib
{
    public class DesignTask
    {
        static int taskNumber;

        int DesignTaskId { get; set; }
        string DesignTaskContent { get; set; }
        DateTime DesignTaskCreationTime { get; set; }
        DateTime DesignTaskLastUpdateTime { get; set; }
    }
}
