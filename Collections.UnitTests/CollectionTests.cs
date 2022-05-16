using NUnit.Framework;
using System.Linq;

namespace Collections.UnitTests
{
    public class CollectionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            // Arrange
            var nums = new Collection<int>();
            // Act
            Assert.That(nums.Count == 0, "Count property");
            // Assert.That(nums.Capacity == 0, "Capacity property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[]");
        }

        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            // Arrange
            var nums = new Collection<int>(5);
            // Act
            Assert.That(nums.Count == 1, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[5]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            // Arrange
            var nums = new Collection<int>(5, 6);
            // Act
            Assert.That(nums.Count == 2, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[5, 6]");
        }

        [Test]
        public void Test_Collection_Add()
        {
            // Arrange
            var nums = new Collection<int>();

            // Act
            nums.Add(7);

            // Assert
            Assert.That(nums.Count == 1, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[7]");
        }

        [Test]
        public void Test_Collection_ConstructorMultipleItemsString()
        {
            // Arrange
            var nums = new Collection<string>("QA");
            // Act
            Assert.That(nums.Count == 1, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[QA]");
        }

        [Test]
        public void Test_Collection_AddRange()
        {
            // Arrange
            var items = new int[] {6, 7, 8};
            var nums = new Collection<int>();

            // Act
            nums.AddRange(items);

            // Assert
            Assert.That(nums.Count == 3, "Count property");
            Assert.AreEqual(nums.Capacity, 16, "Capacity property");
            Assert.That(nums.ToString() == "[6, 7, 8]");
        }

        [Test]
        [Timeout(5000)]

        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }

        [TestCase("Peter", 0, "Peter")]
        [TestCase("Peter, Maria, George", 0, "Peter")]
        [TestCase("Peter, Maria, George", 1, "Maria")]
        [TestCase("Peter, Maria, George", 2, "George")]
        public void Test_Collection_GetByValidIndex(string data, int index, string expectedValue)
        {
            // Arrange
            var nums = new Collection<string>(data.Split(", "));

            // Act
            var actual = nums[index];

            // Assert
            Assert.AreEqual(expectedValue, actual);
        }
    }
}