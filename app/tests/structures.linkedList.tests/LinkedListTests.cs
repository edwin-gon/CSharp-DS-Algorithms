using System;
using structures.linkedLists;
using Xunit;

namespace structures.linkedList.tests
{
    public class LinkedListTest
    {
        [Fact]
        public void CreateList()
        {
            var linkedList = new SinglyLinkedList<int>();

            Assert.Null(linkedList.Head);
        }

        [Fact]
        public void InsertValues()
        {
            var headValue = 1;
            var tailValue = 2;

            var linkedList = new SinglyLinkedList<int>();
            linkedList.Add(headValue);
            linkedList.Add(tailValue);

            Assert.Equal(linkedList.Head.Value, headValue);
            Assert.Equal(linkedList.Head.NextNode.Value, tailValue);
            Assert.Null(linkedList.Head.NextNode.NextNode);
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

            linkedList.Remove(valueToRemove);
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

            testList.Remove(valueToRemove);
            Assert.False(testList.Contains(valueToRemove));
            Assert.Equal(expectedCount, testList.Count());
        }
    }
}
