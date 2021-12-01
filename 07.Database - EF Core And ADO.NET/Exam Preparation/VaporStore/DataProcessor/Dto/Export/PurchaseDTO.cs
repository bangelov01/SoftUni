using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    [XmlType("Purchase")]
    public class PurchaseDTO
    {
        [XmlElement("Card")]
        public string CardNumber { get; set; }
        [XmlElement("Cvc")]
        public string CVC { get; set; }
        [XmlElement("Date")]
        public string Date { get; set; }
        [XmlElement("Game")]
        public GameDTO Game { get; set; }
    }
}
