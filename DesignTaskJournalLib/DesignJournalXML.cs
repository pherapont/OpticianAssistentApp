using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DesignTaskJournalLib
{
    public class DesignJournalXML : IDesignJournal
    {
        const string ROOT_NAME = "DesignJournal";

        XmlDocument XDoc;
        string XFileName;
        XmlElement XRoot;

        public DesignJournalXML(string storeDir)
        {
            XDoc = new XmlDocument();
            XFileName = $"{storeDir}\\{ROOT_NAME}.xml";

            LoadXML();

            XRoot = XDoc.DocumentElement;
        }

        public void SaveDesignTask(DesignTask task)
        {

            XmlElement xTask = XDoc.CreateElement("DesignTask");

            XmlAttribute taskName = XDoc.CreateAttribute("Name");
            XmlAttribute taskPriority = XDoc.CreateAttribute("Priority");
            XmlElement taskContent = XDoc.CreateElement("Content");
            XmlElement taskCreationData = XDoc.CreateElement("CreationData");
            XmlElement taskUpdateData = XDoc.CreateElement("UpdateData");

            XmlText nameText = XDoc.CreateTextNode(task.Name);
            XmlText priorityText = XDoc.CreateTextNode(task.Priority.ToString());
            XmlText contentText = XDoc.CreateTextNode(task.Content);
            XmlText creationDataText = XDoc.CreateTextNode(task.CreationTime.ToString());
            XmlText updateDataText = XDoc.CreateTextNode(task.UpdateTime.ToString());

            taskName.AppendChild(nameText);
            taskPriority.AppendChild(priorityText);
            taskContent.AppendChild(contentText);
            taskCreationData.AppendChild(creationDataText);
            taskUpdateData.AppendChild(updateDataText);

            xTask.Attributes.Append(taskName);
            xTask.Attributes.Append(taskPriority);
            xTask.AppendChild(taskContent);
            xTask.AppendChild(taskCreationData);
            xTask.AppendChild(taskUpdateData);

            XRoot.AppendChild(xTask);

            XDoc.Save(XFileName);
        }

        public (List<DesignTask>, List<DesignTask>, List<DesignTask>) GetJournalsFromStorage()
        {
            List<DesignTask> lowPriorityDesignTasks = new List<DesignTask>();
            List<DesignTask> middlePriorityDesignTasks = new List<DesignTask>();
            List<DesignTask> heighPriorityDesignTasks = new List<DesignTask>();

            foreach (XmlNode xTask in XRoot.ChildNodes)
            {
                DesignTask task = new DesignTask();

                if (xTask.Attributes.Count > 0)
                {
                    XmlNode nameAttr = xTask.Attributes.GetNamedItem("Name");
                    if (nameAttr != null)
                    {
                        task.Name = nameAttr.Value;
                    }
                    XmlNode priorityAttr = xTask.Attributes.GetNamedItem("Priority");
                    if (priorityAttr != null)
                    {
                        task.Priority = (DesignTaskPriority)Enum.Parse(typeof(DesignTaskPriority), priorityAttr.Value);
                    }
                }
                foreach (XmlNode xField in xTask.ChildNodes)
                {
                    if (xField.Name == "Content")
                    {
                        task.Content = xField.InnerText;
                    }
                    else if (xField.Name == "CreationData")
                    {
                        task.CreationTime = DateTime.Parse(xField.InnerText);
                    }
                    else if (xField.Name == "UpdateData")
                    {
                        task.UpdateTime = DateTime.Parse(xField.InnerText);
                    }
                }
                switch (task.Priority)
                {
                    case DesignTaskPriority.Low:
                        lowPriorityDesignTasks.Add(task);
                        break;
                    case DesignTaskPriority.Middle:
                        middlePriorityDesignTasks.Add(task);
                        break;
                    case DesignTaskPriority.High:
                        heighPriorityDesignTasks.Add(task);
                        break;
                }
            }

            return (lowPriorityDesignTasks, middlePriorityDesignTasks, heighPriorityDesignTasks);
        }

        private void LoadXML()
        {
            if (!File.Exists(XFileName))
            {
                string[] initialContent = { "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>", $"<{ROOT_NAME}>", $"</{ROOT_NAME}>" };
                File.WriteAllLines(XFileName, initialContent, System.Text.Encoding.UTF8);
            }

            XDoc.Load(XFileName);
        }
    }
}
