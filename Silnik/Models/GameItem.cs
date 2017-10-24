using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Bazowa klasa dla przedmiotów.
    /// </summary>
    public class GameItem
    {
        public int ItemTypeID { get; set; }

        /// <summary>
        /// Nazwa przedmiotu.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cena przedmiotu.
        /// </summary>
        public int Price { get; set; }

        public GameItem(int itemTypeID, string name, int price)
        {
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Kopiuje przedmiot.
        /// </summary>
        /// <returns></returns>
        public GameItem Clone()
        {
            return new GameItem(ItemTypeID, Name, Price);
        }

        public override string ToString()
        {
            return $"{ItemTypeID} {Name}";
        }
    }
}
