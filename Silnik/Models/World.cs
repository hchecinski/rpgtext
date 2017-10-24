using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silnik.Models
{
    /// <summary>
    /// Klasa reprezentująca świat w grze.
    /// </summary>
    public class World
    {
        /// <summary>
        /// Lista lokacji z których zbudowany jest świat.
        /// </summary>
        private List<Location> _locations = new List<Location>();

        /// <summary>
        /// Dodanie lokacji do świata gry.
        /// </summary>
        /// <param name="xCoordinate">Współrzędna X</param>
        /// <param name="yCoordinate">Współrzędna Y</param>
        /// <param name="name">Nazwa lokacji</param>
        /// <param name="description">Opis lokacji</param>
        /// <param name="imageName">Obrazek lokacji</param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            _locations.Add(loc);
        }

        public void AddLocation(Location location)
        {
            _locations.Add(location);
        }

        /// <summary>
        /// Metoda pobiera lokację z listy o podanych współrzędnych x i y.
        /// </summary>
        /// <param name="xCoordinate">Współrzędna X lokacji.</param>
        /// <param name="yCoordinate">Współrzędna Y lokacji.</param>
        /// <returns>Jeśli lokacja istnieje zwróć ją. W innym przypadku zwórć Null.</returns>
        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            return _locations.FirstOrDefault(loc => loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate);
        }
    }
}
