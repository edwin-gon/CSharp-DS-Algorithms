using structures.linkedLists;
using Xunit;

namespace structures.linkedList.tests
{
    public class SinglyLinkedListTest
    {
        [Fact]
        public void CreateList()
        {
            var linkedList = new SinglyLinkedList<int>();

            Assert.Null(linkedList.GetHead());
        }

        [Fact]
        public void AddValues()
        {
            var headValue = 1;
            var tailValue = 2;

            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(headValue);
            linkedList.Add(tailValue);

            Assert.Equal(linkedList.GetHead().Value, headValue);
            Assert.Equal(linkedList.GetHead().NextNode.Value, tailValue);
            Assert.Null(linkedList.GetHead().NextNode.NextNode);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        public void AddValueToHead(int[] values)
        {
            var testList = new SinglyLinkedList<int>();
            foreach (var item in values)
                testList.Add(item);

            var valueToBeAdded = 2;
            testList.InsertAtHead(valueToBeAdded);
            Assert.Equal(valueToBeAdded, testList.GetHead().Value);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 1 })]
        public void RemoveValueToHead(int[] values)
        {
            var testList = new SinglyLinkedList<int>();
            foreach (var item in values)
                testList.Add(item);

            testList.DeleteAtHead();
            Assert.Null(testList.GetHead());
        }

        [Theory]
        [InlineData(new int[] { }, 0)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2 }, 2)]

        public void CountItems(int[] values, int expectedCount)
        {
            var testList = new SinglyLinkedList<int>();

            foreach (var value in values)
                testList.Add(value);

            Assert.Equal(expectedCount, testList.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ContainsValue(int value)
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);

            Assert.True(linkedList.Contains(value));
        }

        [Theory]
        [InlineData("a", 4)]
        [InlineData("b", 3)]
        [InlineData("c", 4)]
        [InlineData("d", 4)]
        public void RemoveValue(string valueToRemove, int expectedCount)
        {
            var testValues = new string[] { "a", "b", "c", "b", "d" };

            var linkedList = new SinglyLinkedList<string>();
            foreach (var value in testValues)
                linkedList.Add(value);

            linkedList.Delete(valueToRemove);
            Assert.False(linkedList.Contains(valueToRemove));
            Assert.Equal(expectedCount, linkedList.Count());
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, 1, 1)]
        [InlineData(new int[] { 1, 1, 1 }, 1, 0)]
        [InlineData(new int[] { }, 1, 0)]
        public void RemoveValuesHead(int[] testValues, int valueToRemove, int expectedCount)
        {
            var testList = new SinglyLinkedList<int>();

            foreach (var value in testValues)
                testList.Add(value);

            testList.Delete(valueToRemove);
            Assert.False(testList.Contains(valueToRemove));
            Assert.Equal(expectedCount, testList.Count());
        }
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, 3, 2, 2)]
        [InlineData(new int[] { 1, 1, 1 }, 1, 0, 0)]
        [InlineData(new int[] { }, 1, 0, 0)]
        public void RemoveValuesTail(
            int[] testValues,
            int valueToRemove,
            int expectedCount,
            int expectedTail)
        {
            var testList = new SinglyLinkedList<int>();

            foreach (var value in testValues)
                testList.Add(value);

            testList.Delete(valueToRemove);
            Assert.False(testList.Contains(valueToRemove));
            Assert.Equal(expectedCount, testList.Count());
            Assert.Equal(expectedTail, testList.GetTail()?.Value ?? 0);
        }

        [Theory]
        [InlineData(new int[] { }, true)]
        [InlineData(new int[] { 1 }, false)]
        public void IsEmpty(int[] values, bool expectedResult)
        {
            var testList = new SinglyLinkedList<int>();
            foreach (var item in values)
                testList.Add(item);

            var result = testList.IsEmpty();
            Assert.Equal(expectedResult, result);
        }
    }
}
