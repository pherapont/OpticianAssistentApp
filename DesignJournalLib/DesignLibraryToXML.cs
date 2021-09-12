﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DesignJournalLib
{
    internal class DesignLibraryToXML
    {
        XmlDocument DLXDoc;
        string DLXFileName;
        XmlElement DLXRoot;
        string rootName = "designLibrary";

        public DesignLibraryToXML(string storeDir)
        {
            DLXDoc = new XmlDocument();
            DLXFileName = $"{storeDir}\\designLibrary.xml";
            DLXDoc.Load(DLXFileName);
            DLXRoot = DLXDoc.DocumentElement;
        }
        public void SaveDesignTaskToXML(DesignTask task)
        {
            if (!File.Exists(DLXFileName))
            {
                CreateXMLFile();
            }

            XmlElement xTask = DLXDoc.CreateElement("designTask");

            XmlAttribute taskName = DLXDoc.CreateAttribute("Name");
            XmlElement taskContent = DLXDoc.CreateElement("Content");
            XmlElement taskCreationData = DLXDoc.CreateElement("CreationData");
            XmlElement taskUpdateData = DLXDoc.CreateElement("UpdateData");

            XmlText nameText = DLXDoc.CreateTextNode(task.DesignTaskName);
            XmlText contentText = DLXDoc.CreateTextNode(task.DesignTaskContent);
            XmlText creationDataText = DLXDoc.CreateTextNode(task.DesignTaskCreationTime.ToString());
            XmlText updateDataText = DLXDoc.CreateTextNode(task.DesignTaskLastUpdateTime.ToString());

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

        internal List<DesignTask> GetLibrary()
        {
            List<DesignTask> designTasks = new List<DesignTask>();

            foreach (XmlNode xTask in DLXRoot.ChildNodes)
            {
                DesignTask task = new DesignTask();
                XmlNode nameAttr = xTask.Attributes.GetNamedItem("Name");
                if (nameAttr != null)
                {
                    task.DesignTaskName = nameAttr.Value;
                }
            }

            return designTasks;
        }

        private void CreateXMLFile()
        {
            StreamWriter DLXStreamWriter = File.CreateText(DLXFileName);
            DLXStreamWriter.WriteLine($"<{rootName}>");
            DLXStreamWriter.WriteLine($"</{rootName}>");
            DLXStreamWriter.Close();
        }
    }
}