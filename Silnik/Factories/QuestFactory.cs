using Silnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Factories
{
    public static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items need to complete the quest, and its reward items
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));

            // Create the quest
            _quests.Add(new Quest(1,
                                  "Oczyść ziołowy ogród",
                                  "Pozbądź się węży z ogrodu zielarza",
                                  itemsToComplete,
                                  25, 10,
                                  rewardItems));
        }

        public static Quest GetQuestByID(int id)
        {
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
