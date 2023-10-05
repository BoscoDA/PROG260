using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Entities.XML
{
    [XmlRoot(ElementName = "item")]
    internal class GroceryItem
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "uom")]
        public string UnitOfMeasure { get; set; }
    }
}
