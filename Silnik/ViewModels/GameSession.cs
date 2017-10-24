using Silnik.Factories;
using Silnik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.ViewModels
{
    /// <summary>
    /// Klasa reprezentująca sesję gry.
    /// </summary>
    public class GameSession : BaseNotificationClass
    {
        private Location _currentLocation;
        private Monster _currentMonster;

        /// <summary>
        /// Świat gry w którym zapisane są wszystkie lokacje.
        /// </summary>
        public World CurrentWorld { get; set; }

        /// <summary>
        /// Obiekt postaci gracza.
        /// </summary>
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// Aktualna lokacja w której przebywa bohater gry.
        /// </summary>
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;

                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToWest));
                OnPropertyChanged(nameof(HasLocationToSouth));

                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();
            }
        }

        /// <summary>
        /// Widoczny potworek w aktualnej lokacji.
        /// Null jeśli potworka nie ma w lokacji.
        /// </summary>
        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        /// <summary>
        /// Czy na północ istnieje lokacja.
        /// </summary>
        public bool HasLocationToNorth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
            }
        }

        /// <summary>
        /// Czy na wschodzie istnieje lokacja.
        /// </summary>
        public bool HasLocationToEast
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        /// <summary>
        /// Czy na południu istnieje lokacja.
        /// </summary>
        public bool HasLocationToSouth
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        /// <summary>
        /// Czy na zachodzie istnieje lokacja.
        /// </summary>
        public bool HasLocationToWest
        {
            get
            {
                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
            }
        }

        /// <summary>
        /// Czy lokacja posiada potworka.
        /// </summary>
        public bool HasMonster => CurrentMonster != null;

        public GameSession()
        {
            CurrentPlayer = new Player
            {
                Name = "Scott",
                CharacterClass = "Fighter",
                HitPoints = 10,
                Gold = 1000000,
                ExperiencePoints = 0,
                Level = 1
            };

            CurrentWorld = WorldFactory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1002));
        }

        /// <summary>
        /// Idz na północ.
        /// </summary>
        public void MoveNorth()
        {
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }
        }

        /// <summary>
        /// Idz na wschód.
        /// </summary>
        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }
        }

        /// <summary>
        /// Idz na południe.
        /// </summary>
        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }

        /// <summary>
        /// Idź na zachód.
        /// </summary>
        public void MoveWest()
        {
            if (HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }

        /// <summary>
        /// Metoda sprawdza czy w lokacji jest zadanie dla gracza.
        /// Jeśli gracz nie posiada tego zadania to dodaj mu je do listy zadań.
        /// </summary>
        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }

        /// <summary>
        /// Pobierz potworka z lokacji.
        /// </summary>
        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }
    }
}
