using System.IO;
using System.Xml.Serialization;

namespace Recommendations
{
    /// <summary>
    ///  Implement the Advisor interface, recommending a currently
    ///  promoted firework.
    /// </summary>
    public class PromotionAdvisor : IAdvisor 
    {
        public static readonly PromotionAdvisor singleton =
            new PromotionAdvisor();
        private Firework _promoted;

        // look for a promoted firework
        private PromotionAdvisor()
        {
            try
            {
                //string s = FileFinder.GetFileName("config", "strategy.xml");
                string s = "strategy.xml";
                StreamReader r = new StreamReader(s);
                XmlSerializer xs = new XmlSerializer(typeof(string));
                string name = (string) xs.Deserialize(r);
                r.Close();
                _promoted = Firework.Lookup(name);
            }
            catch {}
        }

        /// <summary>
        /// Return true if the constructor was able to find a
        /// promoted firework.
        /// </summary>
        /// <returns>true if the constructor was able to find a
        /// promoted firework.</returns>
        public bool HasItem()
        {
            return _promoted != null;
        }

        /// <summary>
        /// Recommend a nice item for this customer, based what we're
        /// promoting.
        /// </summary>
        /// <param name="c">the customer to cross-sell</param>
        /// <returns>a nice item for the customer to buy</returns>
        public Firework Recommend(Customer c)
        {
            return _promoted;
        }
    }
}
