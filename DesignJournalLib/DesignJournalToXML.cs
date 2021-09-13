using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DesignJournalLib
{
    internal class DesignJournalToXML
    {
        XmlDocument DLXDoc;
        string DLXFileName;
        XmlElement DLXRoot;
        string rootName = "designJournal";

        public DesignJournalToXML(string storeDir)
        {
            DLXDoc = new XmlDocument();
            DLXFileName = $"{storeDir}\\{rootName}.xml";
            if (!File.Exists(DLXFileName))
            {
                CreateXMLFile();
            }
            DLXDoc.Load(DLXFileName);
            DLXRoot = DLXDoc.DocumentElement;
        }

        public void SaveDesignTaskToXML(DesignTask task)
        {
            XmlElement xTask = DLXDoc.CreateElement("designTask");

            XmlAttribute taskName = DLXDoc.CreateAttribute("Name");
            XmlElement taskContent = DLXDoc.CreateElement("Content");
            XmlElement taskCreationData = DLXDoc.CreateElement("CreationData");
            XmlElement taskUpdateData = DLXDoc.CreateElement("UpdateData");

            XmlText nameText = DLXDoc.CreateTextNode(task.Name);
            XmlText contentText = DLXDoc.CreateTextNode(task.Content);
            XmlText creationDataText = DLXDoc.CreateTextNode(task.CreationTime.ToString());
            XmlText updateDataText = DLXDoc.CreateTextNode(task.UpdateTime.ToString());

            taskName.AppendChild(nameText);
            taskContent.AppendChild(contentText);
            taskCreationData.AppendChild(creationDataText);
            taskUpdateData.AppendChild(updateDataText);

            xTask.Attributes.Append(taskName);
            xTask.AppendChild(taskContent);
            xTask.AppendChild(taskCreationData);
            xTask.AppendChild(taskUpdateData);

            DLXRoot.AppendChild(xTask);

            DLXDoc.Save(DLXFileName);
        }

        internal List<DesignTask> GetJournal()
        {
            List<DesignTask> designTasks = new List<DesignTask>();

            foreach (XmlNode xTask in DLXRoot.ChildNodes)
            {
                DesignTask task = new DesignTask();

                if (xTask.Attributes.Count > 0)
                {
                    XmlNode nameAttr = xTask.Attributes.GetNamedItem("Name");
                    if (nameAttr != null)
                    {
                        task.Name = nameAttr.Value;
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
                designTasks.Add(task);
            }

            return designTasks;
        }

        private void CreateXMLFile()
        {
            string[] initialContent = { "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>", $"<{rootName}>", $"</{rootName}>" };
            File.WriteAllLines(DLXFileName, initialContent, System.Text.Encoding.UTF8);
        }
    }
}