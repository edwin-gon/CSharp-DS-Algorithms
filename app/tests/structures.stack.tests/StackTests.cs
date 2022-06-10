using Xunit;

namespace structures.stack.tests
{

    public class StackTests
    {
        [Theory]
        [InlineData(new int[] { }, true)]
        [InlineData(new int[] { 1 }, false)]
        public void IsEmpty(int[] values, bool expectedResponse)
        {
            var testStack = new Stack<int>();
            foreach (var item in values)
                testStack.Push(item);

            var response = testStack.IsEmpty();
            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void AddItemToTop()
        {
            var testStack = new Stack<int>();
            Assert.True(testStack.IsEmpty());

            testStack.Push(1);
            Assert.False(testStack.IsEmpty());
        }

        [Fact]
        public void RemoveTopItem()
        {
            var testStack = new Stack<int>();
            Assert.True(testStack.IsEmpty());

            testStack.Push(1);
            Assert.False(testStack.IsEmpty());

            testStack.Pop();
            Assert.True(testStack.IsEmpty());
        }


        [Fact]
        public void PeekTopItem()
        {
            var expectedResponse = 1;
            var testStack = new Stack<int>();
            testStack.Push(expectedResponse);

            var response = testStack.Peek();

            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void PeekEmptyStackInt()
        {
            var expectedResponse = 0;
            var testStack = new Stack<int>();

            var response = testStack.Peek();
            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void PeekEmptyStackString()
        {
            var testStack = new Stack<string>();

            var response = testStack.Peek();
            Assert.Null(response);
        }
    }
}