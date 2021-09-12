using System;

namespace DesignJournalLib
{
    public class DesignTask
    {
        private static int _taskNumber;
        public DesignTask()
        {
            DesignTaskId = _taskNumber;
            _taskNumber++;
        }

        public int DesignTaskId { get; private set; }
        public string DesignTaskContent { get; set; }
        public string DesignTaskName { get; set; }
        public DateTime DesignTaskCreationTime { get; set; }
        public DateTime DesignTaskLastUpdateTime { get; set; }
    }
}
