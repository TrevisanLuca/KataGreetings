using NUnit.Framework;
using Greeting.Chain;

namespace Greeting.Test
{
    public class ManyNamesWithSomeUpperHandlerTests
    {
        private IGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            var greeter = new HandleMixed();
            _sut = greeter;
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _sut.Handle("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
    }
}