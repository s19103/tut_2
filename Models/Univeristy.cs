using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace tut_2.Models
{
    public class Univeristy
    {
        //[JsonPropertyName]
        [XmlAttribute]
        public string createdAt { get; set; }
        [XmlAttribute]
        public string author { get; set; }
        public List<Student> students { get; set; }
        public List<ActiveStudies> activeStudies { get; set; }

    }
}
