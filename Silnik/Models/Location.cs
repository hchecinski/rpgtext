using Silnik.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Objekt lokacji w grze
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Wspórzędna "X" lokacji.
        /// </summary>
        public int XCoordinate { get; set; }

        /// <summary>
        /// Wspórzędna "Y" lokacji.
        /// </summary>
        public int YCoordinate { get; set; }

        /// <summary>
        /// Nazwa lokacji.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis lokacji.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Obrazek lokacji.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Lista dostępnych zadań, które można podjąć w lokacji.
        /// </summary>
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        /// <summary>
        /// Lista potworków występujących w lokacji.
        /// </summary>
        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        /// <summary>
        /// Metoda dodaje potworka do lokacji. W każdej lokacji może występować tylko jeden typ potworka.
        /// Jeśli chcemy dodać ich więcej to wtedy szansa na spotkanie znim wzrośnie.
        /// </summary>
        /// <param name="monsterID">ID potworka którego chcemy dodać do lokacji.</param>
        /// <param name="chanceOfEncountering">Szansa na spotkanie potworka wchodząc do lokacji.</param>
        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        /// <summary>
        /// Metoda pobierająca potworka z lokacji do walki.
        /// </summary>
        /// <returns>Zwraca potworka który istnieje w lokacji</returns>
        public Monster GetMonster()
        {
            if (!MonstersHere.Any()) return null;

            // Szansa na spotkanie potworka. Sumujemy wszystkie liczby szansy na spotkanie.
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Losujemy liczbę z przedziału <1, totalChances>.
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            // Loop through the monster list, 
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that is the monster to return.
            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // If there was a problem, return the last monster in the list.
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
