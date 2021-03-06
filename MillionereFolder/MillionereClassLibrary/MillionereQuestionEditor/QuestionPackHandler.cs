﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace MillionereQuestionEditor
{
    class QuestionPackHandler
    {
        public static QuestionPack DeserializePack()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "XML files (*.xml)| *.xml",
                DefaultExt = "xml"
            };
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionPack));
            if(ofd.ShowDialog() == true)
                return (QuestionPack) serializer.Deserialize(new FileStream(ofd.FileName, FileMode.Open));
            return null;
        }

        public static void SerializePack(QuestionPack pack)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(QuestionPack));

            using (FileStream fs = new FileStream(pack.Name + " Question Pack.xml",
                FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pack);
            }
        }
    }
}
