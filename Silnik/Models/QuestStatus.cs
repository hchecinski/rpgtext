using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa statusu dla zadań.
    /// </summary>
    public class QuestStatus
    {
        /// <summary>
        /// Zadanie.
        /// </summary>
        public Quest PlayerQuest { get; set; }

        /// <summary>
        /// True dla skonczonego zadania. False dla nie skończonego.
        /// </summary>
        public bool IsCompleted { get; set; }

        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
