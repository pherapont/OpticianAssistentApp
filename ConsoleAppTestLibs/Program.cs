using System;
using System.Collections.Generic;
using DesignJournalLib;

namespace ConsoleAppTestLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            DesignJournal designLibrary = new DesignJournal("C:\\Users\\Oleg\\Desktop\\Б-21-02 (чертежи)\\Журнал");
            DesignTask designTask = new DesignTask { DesignTaskName = "Test" };
            designTask.DesignTaskContent = "Here is task description";
            designTask.DesignTaskCreationTime = DateTime.Now;
            designTask.DesignTaskLastUpdateTime = DateTime.Now;
            designLibrary.SaveDesignTask(designTask);

            DesignJournal dL = new DesignJournal("C:\\Users\\Oleg\\Desktop\\Б-21-02 (чертежи)\\Журнал");
            List<DesignTask> list = dL.GetDesignLibrary();
            foreach (var item in list)
            {
                Console.WriteLine(item.DesignTaskName);
            }
        }
    }
}
