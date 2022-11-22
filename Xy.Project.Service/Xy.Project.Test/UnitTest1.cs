using Xy.Project.Core.App;

namespace Xy.Project.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            App app = new App();
        }
    }
}