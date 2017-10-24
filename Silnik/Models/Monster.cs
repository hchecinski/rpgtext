using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa potworków.
    /// </summary>
    public class Monster : BaseNotificationClass
    {
        public Monster(string name, string imageName, int maximumHitPoints, int hitPoints, int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = $"/Silnik;component/Resources/Images/Monsters/{imageName}";
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }

        private int _hitPoints;

        /// <summary>
        /// Nazwa potwora.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Obrazek potwora.
        /// </summary>
        public string ImageName { get; private set; }

        /// <summary>
        /// Maksymalna ilość punktów życia.
        /// </summary>
        public int MaximumHitPoints { get; private set; }

        /// <summary>
        /// Aktualna ilość punków życia.
        /// </summary>
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }

        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        /// <summary>
        /// Nagroda za zabićie w postaci punków doświadczenia.
        /// </summary>
        public int RewardExperiencePoints { get; private set; }

        /// <summary>
        /// Nagroda w złocie za zabicie potworka.
        /// </summary>
        public int RewardGold { get; private set; }

        /// <summary>
        /// Posiadanie przediomty przez potworka.
        /// </summary>
        public ObservableCollection<ItemQuantity> Inventory { get; set; }
    }
}
