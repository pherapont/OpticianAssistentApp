using System;
using System.Collections.Generic;
using DesignJournalLib;

namespace ConsoleAppTestLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            DesignJournalXML designLibrary = new DesignJournalXML("C:\\Users\\Oleg\\Desktop\\Б-21-02 (чертежи)\\Журнал");
            DesignTask designTask = new DesignTask { Name = "Test" };
            designTask.Content = "Here is task description";
            designTask.CreationTime = DateTime.Now;
            designTask.UpdateTime = DateTime.Now;
            designLibrary.SaveDesignTask(designTask);

            DesignJournalXML dL = new DesignJournalXML("C:\\Users\\Oleg\\Desktop\\Б-21-02 (чертежи)\\Журнал");
            List<DesignTask> list = dL.GetJournalFromStorage();
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Content);
                Console.WriteLine(item.CreationTime);
                Console.WriteLine(item.UpdateTime);
            }
        }
    }
}
