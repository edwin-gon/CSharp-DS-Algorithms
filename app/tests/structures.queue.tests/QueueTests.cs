using Xunit;

namespace structures.queue.tests
{
    public class QueueTest
    {
        [Theory]
        [InlineData(new int[] { }, true)]
        [InlineData(new int[] { 1 }, false)]
        public void IsEmpty(int[] values, bool expectedResponse)
        {
            var testQueue = new Queue<int>();
            foreach (var item in values)
                testQueue.Enqueue(item);

            var response = testQueue.IsEmpty();
            Assert.Equal(expectedResponse, response);
        }

        [Fact]
        public void Enqueue()
        {
            var expectedResponse = 1;
            var testQueue = new Queue<int>();

            Assert.True(testQueue.IsEmpty());

            testQueue.Enqueue(expectedResponse);

            Assert.False(testQueue.IsEmpty());
            Assert.Equal(expectedResponse, testQueue.GetFront());
        }

        [Fact]
        public void Dequeue()
        {
            var expectedResponse = 1;
            var testQueue = new Queue<int>();

            Assert.True(testQueue.IsEmpty());

            testQueue.Enqueue(expectedResponse);

            Assert.False(testQueue.IsEmpty());
            testQueue.Dequeue();

            Assert.True(testQueue.IsEmpty());
        }

        [Fact]
        public void GetTopItem()
        {
            var expectedResponse = 1;
            var testQueue = new Queue<int>();

            Assert.True(testQueue.IsEmpty());

            testQueue.Enqueue(expectedResponse);
            testQueue.Enqueue(2);

            Assert.Equal(expectedResponse, testQueue.GetFront());
        }
    }
}