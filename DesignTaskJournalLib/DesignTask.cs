using System;

namespace DesignTaskJournalLib
{
    public enum DesignTaskPriority { Low, Middle, High }
    public class DesignTask
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public DesignTaskPriority Priority { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
