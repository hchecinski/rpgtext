using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa definuję z jakim prawdopodobieństwem można spotać potworka.
    /// </summary>
    public class MonsterEncounter
    {
        /// <summary>
        /// Id potworka.
        /// </summary>
        public int MonsterID { get; set; }

        /// <summary>
        /// Szansa na spotkanie z potworkiem.
        /// </summary>
        public int ChanceOfEncountering { get; set; }

        public MonsterEncounter(int monsterID, int chanceOfEncountering)
        {
            MonsterID = monsterID;
            ChanceOfEncountering = chanceOfEncountering;
        }
    }
}
