using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa dla broni w grze.
    /// </summary>
    public class Weapon : GameItem
    {
        /// <summary>
        /// Minimalne obrażenia zadawane przez broń.
        /// </summary>
        public int MinimumDamage { get; set; }

        /// <summary>
        /// Maksymalne obrażenia zadawane przez broń.
        /// </summary>
        public int MaximumDamage { get; set; }

        public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage)
            : base(itemTypeID, name, price)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        /// <summary>
        /// Metoda która przesłania metodę Clone z GameItem.
        /// </summary>
        /// <returns>Zwraca kopie broni.</returns>
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}
