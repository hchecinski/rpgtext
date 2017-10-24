using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa postaci gracza.
    /// </summary>
    public class Player : BaseNotificationClass
    {
        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        #region fields
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;
        #endregion

        #region properties

        /// <summary>
        /// Nazwa gracza.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Klasa gracza.
        /// </summary>
        public string CharacterClass
        {
            get
            {
                return _characterClass;
            }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }

        /// <summary>
        /// Aktualne punkty życia gracza.
        /// </summary>
        public int HitPoints
        {
            get
            {
                return _hitPoints;
            }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        /// <summary>
        /// Aktualne punkty doświaczenia gracza.
        /// </summary>
        public int ExperiencePoints
        {
            get
            {
                return _experiencePoints;
            }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }

        /// <summary>
        /// Aktualny poziom gracza.
        /// </summary>
        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        /// <summary>
        /// Aktualna liczba posiadanego złota przez gracza.
        /// </summary>
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        /// <summary>
        /// Posiadane przedmioty przez gracza.
        /// </summary>
        public ObservableCollection<GameItem> Inventory { get; set; }

        /// <summary>
        /// Status posiadanych zadań przez gracza.
        /// </summary>
        public ObservableCollection<QuestStatus> Quests { get; set; }

        /// <summary>
        /// Lista broni pobrana z Inventory.
        /// </summary>
        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();

        /// <summary>
        /// Metoda dodaje przedmiot do inwentarza.
        /// </summary>
        /// <param name="item">Przedmiot który ma zostać dodany do listy.</param>
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            //"Hej jest nowy przedmiot w inwentarzu, sprawdź czy to nie broń!"
            OnPropertyChanged(nameof(Weapons));
        }
        #endregion

        #region events
        #endregion
    }
}
