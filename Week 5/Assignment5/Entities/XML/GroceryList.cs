using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assignment5.Entities.XML
{
    [XmlRoot(ElementName = "menu")]
    public class GroceryList
    {
        [XmlElement(ElementName = "item")]
        public List<GroceryItem> GroceryItems = new List<GroceryItem>();

    }
}
