using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa przechowująca ilości.
    /// </summary>
    public class ItemQuantity
    {
        /// <summary>
        /// Id obiektu.
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Ilość obiektu.
        /// </summary>
        public int Quantity { get; set; }

        public ItemQuantity(int itemID, int quantity)
        {
            ItemID = itemID;
            Quantity = quantity;
        }
    }
}
