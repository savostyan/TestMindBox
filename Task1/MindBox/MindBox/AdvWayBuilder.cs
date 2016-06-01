using System.Collections.Generic;

namespace MindBox
{
    public static class AdvWayBuilder
    {
        /// <summary>
        /// Получение первой карты путешествия
        /// </summary>
        /// <param name="advCards">Список карт</param>
        /// <returns>Карта путешествия</returns>
        public static AdvCard GetFirstCard(List<AdvCard> advCards)
        {
            AdvCard currentCard = new AdvCard();
            List<AdvCard> currentAdvCards = advCards;
            bool cityToFound = false;
            
            if (currentAdvCards.Count == 1)
            {
                return currentAdvCards[0];
            }

            for (int i = 0; i < advCards.Count; i++)
            {
                currentCard = advCards[i];
                for (int j = 0; j < currentAdvCards.Count; j++)
                {
                    if (currentCard.CityFrom == currentAdvCards[j].CityTo)
                    {
                        cityToFound = true;
                        break;
                    }
                }
                if (!cityToFound)
                {
                    advCards.RemoveAt(i);
                    return currentCard;
                }
                cityToFound = false;
            }
            
            return new AdvCard();
        }

        /// <summary>
        /// Получение следующей карты путешествия
        /// </summary>
        /// <param name="advCards">Список карт</param>
        /// <param name="currentCard">Текущая карта путешествия</param>
        /// <returns>Карта путешествия</returns>
        public static AdvCard GetNextCard(List<AdvCard> advCards, AdvCard currentCard)
        {
            AdvCard currentAdvCard = new AdvCard();

            if (!string.IsNullOrEmpty(currentCard.CityTo) && currentCard.CityTo != AdvCard.NO_CITY)
            {
                for (int i = 0; i < advCards.Count; i++)
                {
                    currentAdvCard = advCards[i];
                    if (currentAdvCard.CityFrom == currentCard.CityTo)
                    {
                        advCards.RemoveAt(i);
                        return currentAdvCard;
                    }
                }
            }
            return new AdvCard();
        }

        /// <summary>
        /// Упорядочивание карточек путешествия
        /// </summary>
        /// <param name="advCards"></param>
        public static List<AdvCard> SortAdvCards(List<AdvCard> advCards)
        {
            if (advCards.Count <= 1)
            {
                return advCards;
            }

            List<AdvCard> sortedAdvCards = new List<AdvCard>();
            AdvCard firstCard = GetFirstCard(advCards);
            sortedAdvCards.Add(firstCard);

            AdvCard currentCard = firstCard;
            while (advCards.Count != 0)
            {
                currentCard = GetNextCard(advCards, currentCard);
                sortedAdvCards.Add(currentCard);
            }

            return sortedAdvCards;
        }
    }
}
