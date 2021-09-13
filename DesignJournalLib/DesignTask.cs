using System;

namespace DesignJournalLib
{
    public class DesignTask
    {
        // TODO нумерация задач при запуске программы всегда будет начинаться с 0, а надо с номера соответств. списку нал. задач

        private static int _taskNumber;
        public DesignTask()
        {
            Id = _taskNumber;
            _taskNumber++;
        }

        public int Id { get; private set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
