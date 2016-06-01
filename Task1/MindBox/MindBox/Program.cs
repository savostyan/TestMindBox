using System;
using System.Collections.Generic;

namespace MindBox
{
    class Program
    {
        static void PrintCards(List<AdvCard> advCards)
        {
            foreach (var card in advCards)
            {
                Console.Write(string.Format("Город отправления: {0} | ", card.CityFrom));
                Console.WriteLine(string.Format("Город назначения: {0} | ", card.CityTo));
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Владивосток", "Киев"),
                new AdvCard("Каир", "Ливерпуль"),
                new AdvCard("Берлин", "Вашингтон"),
                new AdvCard("Атланта", "Сочи"),
                new AdvCard("Мельбурн", "Рим"),
                new AdvCard("Париж", "Берлин"),
                new AdvCard("Ливерпуль", "Владивосток"),
                new AdvCard("Москва", "Париж"),
                new AdvCard("Вашингтон", "Атланта"),
                new AdvCard("Киев", "Мельбурн"),
                new AdvCard("Сочи", "Каир")
            };

            List<AdvCard> sortedAdvCards = AdvWayBuilder.SortAdvCards(cards);

            PrintCards(sortedAdvCards);
        }
    }
}
