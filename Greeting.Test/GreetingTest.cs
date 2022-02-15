using NUnit.Framework;
using Greeting.Chain;

namespace Greeting.Test
{
    public class GreetingTests
    {
        private IGreetingHandler _sut;

        [SetUp]
        public void Setup()
        {
            var greeter = new HandleNone();
            greeter
                //.SetNext(new HandleSpecial())
                .SetNext(new HandleEmpty())
                //.SetNext(new HandleOne()) //Now unnecessary
                //.SetNext(new HandleTwo()) //Now unnecessary
                //.SetNext(new HandleThreeOrMore()) //Now unnecessary
                .SetNext(new HandleMixed());
            _sut = greeter;
        }

        [Test]
        public void Should_Add_Greeting_To_Name()
        {
            var expected = "Hello, Andrea.";
            var actual = _sut.Handle("Andrea");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Null_Name()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Handle(null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Uppercase_Name()
        {
            var expected = "HELLO, ANDREA!";
            var actual = _sut.Handle("ANDREA");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Two_Name()
        {
            var expected = "Hello, Andrea and Franco.";
            var actual = _sut.Handle("Andrea", "Franco");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name()
        {
            var expected = "Hello, Andrea, Franco and Giuseppe.";
            var actual = _sut.Handle("Andrea", "Franco", "Giuseppe");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Should_Handle_Multiple_Name_With_Upper()
        {
            var expected = "Hello, Andrea and Franco. AND HELLO GIUSEPPE!";
            var actual = _sut.Handle("Andrea", "Franco", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_Mixed_Names_With_Separator()
        {
            var expected = "Hello, Andrea, Franco and Mario. AND HELLO GIUSEPPE!";
            var actual = _sut.Handle("Andrea", "Franco, Mario", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_Mixed_Names()
        {
            var expected = "Hello, Andrea and Franco, Mario. AND HELLO GIUSEPPE!";
            var actual = _sut.Handle("Andrea", "\"Franco, Mario\"", "GIUSEPPE");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_Mixed_Names_V2()
        {
            var expected = "Hello, Andrea and Franco, Mario. AND HELLO, GIUSEPPE, FEDERICO AND MARCO!";
            var actual = _sut.Handle("Andrea", "GIUSEPPE", "\"Franco, Mario\"", "FEDERICO, MARCO");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_Multiple_Uppercase_Names_V2()
        {
            var expected = "HELLO, GIUSEPPE, FEDERICO AND MARCO!";
            var actual = _sut.Handle("GIUSEPPE", "FEDERICO", "MARCO");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_Multiple_Empty_Names()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Handle("", ",", "    ");

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Should_Handle_One_Empty_Names()
        {
            var expected = "Hello, my friend.";
            var actual = _sut.Handle("   ");

            Assert.AreEqual(expected, actual);
        }
    }
}