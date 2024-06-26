using System;
using System.IO;
using System.Xml.Serialization;
 
namespace Recommendations
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer 
    {
        private IAdvisor _advisor;
        public static readonly int BIG_SPENDER_DOLLARS = 1000;

        /// <summary>
        /// Return true if this customer has registered (or entered)
        /// his or her preference profile.
        /// </summary>
        /// <returns>true if this customer has registered (or entered)
        /// his or her preference profile. This method is not
        /// actually implemented.</returns>
        public bool IsRegistered()
        {
            return false;
        }

        /// <summary>
        /// Return the amount of dough this customer has spent with
        /// us since the provided date.
        /// </summary>
        /// <param name="date">Since when?</param>
        /// <returns>the amount of dough this customer has spent with
        /// us since the provided date; not actually implemented.
        /// </returns>
        public double SpendingSince(DateTime date)
        {
            return 1000;
        }

        private IAdvisor GetAdvisor()
        {
            if (_advisor == null)
            {
                if (PromotionAdvisor.singleton.HasItem())
                {
                    _advisor = PromotionAdvisor.singleton;
                }
                else if (IsRegistered())
                {
                    _advisor = GroupAdvisor.singleton;
                }
                else if (IsBigSpender())
                {
                    _advisor = ItemAdvisor.singleton;
                }
                else
                {
                    _advisor = RandomAdvisor.singleton;
                }
            }
            return _advisor;
        }

        /// <summary>
        /// Return a firework to recommend to this customer.
        /// </summary>
        /// <returns>a firework to recommend to this customer. This
        /// method is refactored to employ the Strategy
        /// pattern.</returns>
        public Firework GetRecommended()
        {
            return GetAdvisor().Recommend(this);
        }

        private bool IsBigSpender()
        {
            return SpendingSince(DateTime.Now.AddYears(-1)) > BIG_SPENDER_DOLLARS;
        }
    }
}
