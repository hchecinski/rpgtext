using Silnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Factories
{
    public class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Spiczasty patyk", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Zardzewiały miecz", 5, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "Kieł węża", 1));
            _standardGameItems.Add(new GameItem(9002, "Skóra węża", 2));
            _standardGameItems.Add(new GameItem(9003, "Ogon szczura", 1));
            _standardGameItems.Add(new GameItem(9004, "Futro szczura", 2));
            _standardGameItems.Add(new GameItem(9005, "Noga pająka", 1));
            _standardGameItems.Add(new GameItem(9006, "Pajęcza nić", 2));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }
    }
}
