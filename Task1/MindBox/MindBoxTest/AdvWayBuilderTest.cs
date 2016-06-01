using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBox;
using System.Collections.Generic;

namespace MindBoxTest
{
    [TestClass]
    public class AdvWayBuilderTest
    {
        #region GetFirstCardTest

        [TestMethod]
        public void GetFirstCardTest_Count_1()
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Владивосток", "Киев")
            };

            AdvCard expectedCard = new AdvCard("Владивосток", "Киев");
            AdvCard realCard = AdvWayBuilder.GetFirstCard(cards);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);
        }

        [TestMethod]
        public void GetFirstCardTest_Count_More1()
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Сочи", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Вашингтон"),
                new AdvCard("Киев", "Сочи"),
                new AdvCard("Владивосток", "Киев")
            };

            List<AdvCard> sortedCards = new List<AdvCard>()
            {
                new AdvCard("Владивосток", "Киев"),
                new AdvCard("Киев", "Сочи"),
                new AdvCard("Сочи", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Вашингтон")
            };

            AdvCard expectedCard = new AdvCard("Владивосток", "Киев");
            AdvCard realCard = AdvWayBuilder.GetFirstCard(cards);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);
        }

        #endregion

        #region GetNextCardTest

        [TestMethod]
        public void GetNextCardTest_NoCity()
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Сочи", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Вашингтон"),
                new AdvCard("Киев", "Сочи"),
                new AdvCard("Владивосток", "Киев")
            };
            AdvCard card = new AdvCard("", "");
            AdvCard realCard = AdvWayBuilder.GetNextCard(cards, card);
            AdvCard expectedCard = new AdvCard();

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);

            card = new AdvCard("City", "");
            realCard = AdvWayBuilder.GetNextCard(cards, card);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);

            card = new AdvCard("", AdvCard.NO_CITY);
            realCard = AdvWayBuilder.GetNextCard(cards, card);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);

            card = new AdvCard("City", AdvCard.NO_CITY);
            realCard = AdvWayBuilder.GetNextCard(cards, card);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);

            card = new AdvCard("City", "City2");
            realCard = AdvWayBuilder.GetNextCard(cards, card);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);
        }

        [TestMethod]
        public void GetNextCardTest_ExistsCities()
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Сочи", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Вашингтон"),
                new AdvCard("Киев", "Сочи"),
                new AdvCard("Владивосток", "Киев")
            };

            List<AdvCard> sortedCards = new List<AdvCard>()
            {
                new AdvCard("Владивосток", "Киев"),
                new AdvCard("Киев", "Сочи"),
                new AdvCard("Сочи", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Вашингтон")
            };

            AdvCard card = new AdvCard("Сочи", "Ливерпуль");
            AdvCard expectedCard = new AdvCard("Ливерпуль", "Вашингтон");
            AdvCard realCard = AdvWayBuilder.GetNextCard(cards, card);

            Assert.AreEqual(realCard.CityFrom, expectedCard.CityFrom);
            Assert.AreEqual(realCard.CityTo, expectedCard.CityTo);
        }

        #endregion

        #region SortAdvCardsTest

        [TestMethod]
        public void SortAdvCardsTest_Count_0()
        {
            List<AdvCard> cards = new List<AdvCard>();
            List<AdvCard> expectedCards = new List<AdvCard>() { };
            List<AdvCard> realCards = AdvWayBuilder.SortAdvCards(cards);

            Assert.AreEqual(realCards.Count, 0);
        }

        [TestMethod]
        public void SortAdvCardsTest_Count_1()
        {
            List<AdvCard> cards = new List<AdvCard>()
            {
                new AdvCard("Владивосток", "Киев")
            };

            List<AdvCard> expectedCards = new List<AdvCard>() { new AdvCard("Владивосток", "Киев") };
            List<AdvCard> realCards = AdvWayBuilder.SortAdvCards(cards);

            for (int i = 0; i < expectedCards.Count; i++)
            {
                Assert.AreEqual(expectedCards[i].CityFrom, realCards[i].CityFrom);
                Assert.AreEqual(expectedCards[i].CityTo, realCards[i].CityTo);
            }
        }

        [TestMethod]
        public void SortAdvCardsTest()
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
                new AdvCard("Сочи", "Каир"),
            };

            List<AdvCard> expectedCards = new List<AdvCard>()
            {
                new AdvCard("Москва", "Париж"),
                new AdvCard("Париж", "Берлин"),
                new AdvCard("Берлин", "Вашингтон"),
                new AdvCard("Вашингтон", "Атланта"),
                new AdvCard("Атланта", "Сочи"),
                new AdvCard("Сочи", "Каир"),
                new AdvCard("Каир", "Ливерпуль"),
                new AdvCard("Ливерпуль", "Владивосток"),
                new AdvCard("Владивосток", "Киев"),
                new AdvCard("Киев", "Мельбурн"),
                new AdvCard("Мельбурн", "Рим")
            };

            List<AdvCard> realCards = AdvWayBuilder.SortAdvCards(cards);

            for (int i = 0; i < expectedCards.Count; i++)
            {
                Assert.AreEqual(expectedCards[i].CityFrom, realCards[i].CityFrom);
                Assert.AreEqual(expectedCards[i].CityTo, realCards[i].CityTo);
            }
        }

        #endregion
    }
}
