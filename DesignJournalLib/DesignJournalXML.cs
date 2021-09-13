using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DesignJournalLib
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
            if (!File.Exists(XFileName))
            {
                Journal = new List<DesignTask>();
                CreateXMLFile();
                XDoc.Load(XFileName);
                XRoot = XDoc.DocumentElement;
            }
            else
            {
                XDoc.Load(XFileName);
                XRoot = XDoc.DocumentElement;
                Journal = GetJournalFromStorage();
            }
        }

        public List<DesignTask> Journal { get; private set; }

        public void SaveDesignTask(DesignTask task)
        {
            Journal.Add(task);

            XmlElement xTask = XDoc.CreateElement("DesignTask");

            XmlAttribute taskName = XDoc.CreateAttribute("Name");
            XmlElement taskContent = XDoc.CreateElement("Content");
            XmlElement taskCreationData = XDoc.CreateElement("CreationData");
            XmlElement taskUpdateData = XDoc.CreateElement("UpdateData");

            XmlText nameText = XDoc.CreateTextNode(task.Name);
            XmlText contentText = XDoc.CreateTextNode(task.Content);
            XmlText creationDataText = XDoc.CreateTextNode(task.CreationTime.ToString());
            XmlText updateDataText = XDoc.CreateTextNode(task.UpdateTime.ToString());

            taskName.AppendChild(nameText);
            taskContent.AppendChild(contentText);
            taskCreationData.AppendChild(creationDataText);
            taskUpdateData.AppendChild(updateDataText);

            xTask.Attributes.Append(taskName);
            xTask.AppendChild(taskContent);
            xTask.AppendChild(taskCreationData);
            xTask.AppendChild(taskUpdateData);

            XRoot.AppendChild(xTask);

            XDoc.Save(XFileName);
        }

        public List<DesignTask> GetJournalFromStorage()
        {
            List<DesignTask> designTasks = new List<DesignTask>();

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
            string[] initialContent = { "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>", $"<{ROOT_NAME}>", $"</{ROOT_NAME}>" };
            File.WriteAllLines(XFileName, initialContent, System.Text.Encoding.UTF8);
        }
    }
}