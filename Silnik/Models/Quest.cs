using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa zadania w grze
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// Id zadania.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nazwa zadania.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis zadania.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Przedmioty potrzebne do ukończenia zadania.
        /// </summary>
        public List<ItemQuantity> ItemsToComplete { get; set; }

        /// <summary>
        /// Nagroda w punktach doświadczenia.
        /// </summary>
        public int RewardExperiencePoints { get; set; }

        /// <summary>
        /// Nagroda w złocie.
        /// </summary>
        public int RewardGold { get; set; }

        /// <summary>
        /// Nagroda w przedmiotach.
        /// </summary>
        public List<ItemQuantity> RewardItems { get; set; }

        public Quest(int id, string name, string description, List<ItemQuantity> itemsToComplete,
                     int rewardExperiencePoints, int rewardGold, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemsToComplete = itemsToComplete;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
        }
    }
}
