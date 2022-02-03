using System;
using DataStructures.LinkedList;
using Xunit;

namespace DataStructures.Tests.LinkedList
{
    public class LinkedListTest
    {
        [Fact]
        public void InsertValue()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);

            Assert.Equal(1, linkedList.Count);
            Assert.Equal(linkedList.Head, linkedList.Tail);
            Assert.Null(linkedList.Tail.NextNode);
        }

        [Fact]
        public void InsertValues()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);

            Assert.NotEqual(linkedList.Head.Value, linkedList.Tail.Value);
            Assert.Null(linkedList.Tail.NextNode);
        }

        [Fact]
        public void FindValue()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(2);

            var result = linkedList.Find(2);
            Assert.Equal(2, result.Value);
            Assert.NotNull(result.NextNode);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void RemoveValue(int valueToRemove, int expectedCount)
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(2);

            linkedList.Remove(valueToRemove);
            Assert.Equal(expectedCount, linkedList.Count);
        }
    }
}
