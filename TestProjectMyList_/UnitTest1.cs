using LibraryClass;
using MyList;
namespace TestProjectMyList_
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_Default()
        {
            // Arrange & Act
            MyList<BankCard> list = new MyList<BankCard>();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Constructor_Size()
        {
            // Arrange
            int size = 5;

            // Act
            MyList<BankCard> list = new MyList<BankCard>(size);

            // Assert
            Assert.AreEqual(size, list.Count);
        }

        [TestMethod]
        public void NegativeSize()
        {
            // Arrange
            int size = -5;

            // Act & Assert
            try
            {
                MyList<BankCard> list = new MyList<BankCard>(size);
                Assert.Fail("Expected an exception to be thrown");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Размер меньше 0", ex.Message);
            }
        }

        [TestMethod]
        public void AddToEnd_AddsItemToEndOfList()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();

            // Act
            list.AddToEnd(card2);

            // Assert
            Assert.IsTrue(list.Contains(card2));
        }

        [TestMethod]
        public void FindItem_Correct()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card2);

            // Act
            Point<BankCard> foundItem = list.FindItem(card1);

            // Assert
            Assert.IsNotNull(foundItem);
            Assert.AreEqual(card1, foundItem.Data);
        }

        [TestMethod]
        public void RemoveEvenItems_Correct()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            BankCard card3 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card2);
            list.AddToEnd(card3);
            int initialCount = list.Count;

            // Act
            list.RemoveEvenItems();

            // Assert
            Assert.AreEqual(initialCount - 1, list.Count);
        }

        [TestMethod]
        public void RemoveEvenItems_One()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            list.AddToEnd(card1);

            // Act
            list.RemoveEvenItems();

            // Assert
            Assert.AreEqual(1, list.Count);
        }

        public void RemoveEvenItems_Zero()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();

            // Act
            list.RemoveEvenItems();

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveEvenItems_EvenCount()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            BankCard card3 = new BankCard();
            BankCard card4 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card2);
            list.AddToEnd(card3);
            list.AddToEnd(card4);

            // Act
            list.RemoveEvenItems();

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(list.Contains(card1));
            Assert.IsTrue(list.Contains(card3));
        }

        [TestMethod]
        public void AddAfter_Item()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            BankCard card3 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card3);

            // Act
            list.AddAfter(card1, card2);

            // Assert
            Assert.AreEqual(card2, list.FindItem(card1)?.Next?.Data);
        }


        [TestMethod]
        public void AddAfter_AddToEndOfList()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            list.AddToEnd(card1);

            // Act
            list.AddAfter(card1, card2);

            // Assert
            Assert.AreEqual(card2, list.GetBeging()?.Next?.Data);
        }

        [TestMethod]
        public void AddAfter_ItemFoundMultipleTimes_AddsAfterFirstOccurrence()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            BankCard card3 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card2);
            list.AddToEnd(card1);

            // Act
            list.AddAfter(card1, card3);

            // Assert
            Assert.AreEqual(card3, list.FindItem(card1)?.Next?.Data);
        }


        [TestMethod]
        public void ClearAllItems()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            BankCard card2 = new BankCard();
            list.AddToEnd(card1);
            list.AddToEnd(card2);

            // Act
            list.Clear();

            // Assert
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.GetBeging());
        }

        [TestMethod]
        public void CloneOfList()
        {
            // Arrange
            MyList<BankCard> originalList = new MyList<BankCard>();
            BankCard card1 = new BankCard();
            originalList.AddToEnd(card1);

            // Act
            MyList<BankCard> clonedList = originalList.Clone();

            // Assert
            Assert.AreNotSame(originalList, clonedList);
            Assert.AreEqual(originalList.Count, clonedList.Count);
        }

        [TestMethod]
        public void Constructor_Parameterized()
        {
            // Arrange
            int data = 10;

            // Act
            Point<int> point = new Point<int>(data);

            // Assert
            Assert.AreEqual(data, point.Data);
            Assert.IsNull(point.Next);
            Assert.IsNull(point.Pred);
        }

        [TestMethod]
        public void ToString_Returns()
        {
            // Arrange
            int data = 10;
            Point<int> point = new Point<int>(data);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(data.ToString(), result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsData()
        {
            // Arrange
            int data = 10;
            Point<int> point = new Point<int>(data);

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(data.GetHashCode(), hashCode);
        }

        [TestMethod]
        public void NextProperty_Setter_SetsNextCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Next = point2;

            // Assert
            Assert.AreEqual(point2, point1.Next);
        }

        [TestMethod]
        public void PredProperty_Setter_SetsPredCorrectly()
        {
            // Arrange
            Point<int> point1 = new Point<int>();
            Point<int> point2 = new Point<int>();

            // Act
            point1.Pred = point2;

            // Assert
            Assert.AreEqual(point2, point1.Pred);
        }

        [TestMethod]
        public void MakeRandomData_CreatesPointWithRandomData()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();

            // Act
            Point<BankCard> randomPoint = list.MakeRandomData();

            // Assert
            Assert.IsNotNull(randomPoint);
            Assert.IsNotNull(randomPoint.Data);

        }

        [TestMethod]
        public void MakeRandomItem_CreatesRandomItem()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();

            // Act
            BankCard randomItem = list.MakeRandomItem();

            // Assert
            Assert.IsNotNull(randomItem);
        }

        [TestMethod]
        public void MakeRandomItem_CreatesItem()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>(2);

            // Act
            BankCard randomItem1 = list.MakeRandomItem();
            BankCard randomItem2 = list.MakeRandomItem();

            // Assert
            Assert.IsNotNull(randomItem1);
            Assert.IsNotNull(randomItem2);
            Assert.IsTrue(list.Contains(randomItem1));
            Assert.IsTrue(list.Contains(randomItem2));

        }

        [TestMethod]
        public void Print_WritesListElementsToConsole()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard("1234567890123456", "John Doe", 2025, 1);
            BankCard card2 = new BankCard("6543210987654321", "Jane Doe", 2024, 2);
            list.AddToEnd(card1);
            list.AddToEnd(card2);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            list.Print();
            string printedText = sw.ToString();

            // Assert
            Assert.IsTrue(printedText.Contains(card1.ToString()));
            Assert.IsTrue(printedText.Contains(card2.ToString()));
        }

        [TestMethod]
        public void GetBeging_ReturnsBeginningPoint()
        {
            // Arrange
            MyList<BankCard> list = new MyList<BankCard>();
            BankCard card1 = new BankCard("1234567890123456", "John Doe", 2025, 1);
            list.AddToEnd(card1);

            // Act
            Point<BankCard> beginningPoint = list.GetBeging();

            // Assert
            Assert.IsNotNull(beginningPoint);
            Assert.AreEqual(card1, beginningPoint.Data);
        }
    }
}