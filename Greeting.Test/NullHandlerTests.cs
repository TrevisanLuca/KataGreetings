using NUnit.Framework;
using Greeting.Chain;

namespace Greeting.Test
{
    public class NullHandlerTests
    {
        private IGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            var greeter = new HandleNone();
            _sut = greeter;
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Handle(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
