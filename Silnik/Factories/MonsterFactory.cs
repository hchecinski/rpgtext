using Silnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Factories
{
    public static class MonsterFactory
    {
        /// <summary>
        /// Metoda tworząca potworka o podanym ID.
        /// </summary>
        /// <param name="monsterID">ID potworka.</param>
        /// <returns></returns>
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake = new Monster("Wąż", "Snake.png", 4, 4, 1, 2, 5, 1);

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;

                case 2:
                    Monster rat = new Monster("Szczur", "Rat.png", 5, 5, 1, 2, 5, 1);

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    Monster giantSpider = new Monster("Gigantyczny pająk", "GiantSpider.png", 10, 10, 1, 4, 10, 3);

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);

                    return giantSpider;

                default:
                    throw new ArgumentException($"Potworek o Id '{monsterID}' nie istnieje");
            }
        }

        /// <summary>
        /// Metoda dodaje 'loot' do potworków.
        /// </summary>
        /// <param name="monster">Obiekt potworka do którego chcemy dodać jakiś przedmiot.</param>
        /// <param name="itemID">Id przedmiotu który przemy dodać do potworka.</param>
        /// <param name="percentage">Procentowa szansa na sukces. Im liczba większa tym większe prawdopodobieństwo że z potworka coś wypadnie.</param>
        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}
