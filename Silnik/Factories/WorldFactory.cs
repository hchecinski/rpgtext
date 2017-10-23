using Silnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Factories
{
    public static class WorldFactory
    {
        public static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Pole ziemniaków",
                "Rośnie tutaj wiele ziemniaką a między nimi ukrywają się szczury.",
                "/Silnik;component/Resources/Images/Locations/FarmFields.png");
            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, -1, "Chałupa chłopa",
                "To jest dom twojego sąsiada Tomasza.",
                "/Silnik;component/Resources/Images/Locations/Farmhouse.png");

            newWorld.AddLocation(0, -1, "Dom",
                "Tutaj jest twój dom",
                "/Silnik;component/Resources/Images/Locations/Home.png");

            newWorld.AddLocation(-1, 0, "Sklep",
                "Sklep wielobranżowy.",
                "/Silnik;component/Resources/Images/Locations/Trader.png");

            newWorld.AddLocation(0, 0, "Plac główny",
                "Widzisz tutaj fontanne.",
                "/Silnik;component/Resources/Images/Locations/TownSquare.png");

            newWorld.AddLocation(1, 0, "Miejska brama",
                "Ta brama broni przed przedostaniem się do miasta gigantycznych pająków.",
                "/Silnik;component/Resources/Images/Locations/TownGate.png");

            newWorld.AddLocation(2, 0, "Las pająków",
                "Drzewa w tym lesie są pokrytę wielkimi pajęczynami.",
                "/Silnik;component/Resources/Images/Locations/SpiderForest.png");
            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Chata zielarza",
                "Widzisz małą drewnianą chatę pomalowaną na zielono.",
                "/Silnik;component/Resources/Images/Locations/HerbalistsHut.png");
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Ogród zielarza",
                "Wiele różnych roślin rośnie w ogródku, gdzie ukrywają się węże.",
                "/Silnik;component/Resources/Images/Locations/HerbalistsGarden.png");
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
