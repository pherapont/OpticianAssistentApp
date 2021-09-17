using System;

namespace OpticianAssistentUI
{
    enum TaskPriority { Heigh, Middle, Low };
    internal class DesignTaskData
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
