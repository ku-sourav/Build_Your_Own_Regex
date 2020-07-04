using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Regex.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMatchOne()
        {
            var ans = Program.MatchOne('H', 'H');
            Assert.AreEqual(true, ans);
            ans = Program.MatchOne(' ', 'a');
            Assert.AreEqual(false, ans);
            ans = Program.MatchOne('a', ' ');
            Assert.AreEqual(false, ans);
            ans = Program.MatchOne('.', 'a');
            Assert.AreEqual(true, ans);
            ans = Program.MatchOne('a', 'a');
            Assert.AreEqual(true, ans);
        }

        [TestMethod]
        public void TestMatchStrigstart()
        {
            var ans = Program.Match("a.c", "abc");
            Assert.AreEqual(true, ans);
        }

        [TestMethod]
        public void TestSearchStart()
        {
            var ans = Program.Search("^bc", "bcd");
            Assert.AreEqual(true, ans);

            ans = Program.Search("^bc", "adbce");
            Assert.AreEqual(false, ans);
        }

        [TestMethod]
        public void TestQuestion()
        {
            var ans = Program.Search("a?b?c", "abc");
            Assert.AreEqual(true, ans);

            ans = Program.Search("ab?c", "ac");
            Assert.AreEqual(true, ans);

            ans = Program.Search("a?b?c?", " ");
            Assert.AreEqual(true, ans);
        }
        [TestMethod]
        public void Testempty()
        {
            var ans = Program.Search("abc","");         //empty text
            Assert.AreEqual(false, ans);

            ans = Program.Search("", "abc");            //empty pattern
            Assert.AreEqual(true, ans);
        }

        [TestMethod]
        public void TestMatchStar()
        {
            var ans = Program.Search("a*", "aaaaa");
            Assert.AreEqual(true, ans);

            ans = Program.Search("a*", "");
        }
    }
}
