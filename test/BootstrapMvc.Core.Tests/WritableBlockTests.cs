using System;
using System.IO;
using Moq;
using Xunit;

namespace BootstrapMvc.Core
{
    public class WritableBlockTests
    {
        private MockRepository mocks;
        private Mock<IBootstrapContext> contextMock;

        public WritableBlockTests()
        {
            mocks = new MockRepository(MockBehavior.Strict);
            contextMock = mocks.Create<IBootstrapContext>();
        }

        [Fact]
        public void Test_WriteTo_Calls_WriteTo_On_NextBlock()
        {
            var b1 = new DummyWritableBlock() { Content = "1" };
            var b2 = new DummyWritableBlock() { Content = "2" };

            b1.AppendNextBlock(b2);

            using (var sw = new StringWriter())
            {
                b1.WriteTo(sw, contextMock.Object);
                Assert.Equal("12", sw.ToString());
            }
        }

        [Fact]
        public void Test_Append_Appends_To_End()
        {
            var b1 = new DummyWritableBlock() { Content = "1" };
            var b2 = new DummyWritableBlock() { Content = "2" };
            var b3 = new DummyWritableBlock() { Content = "3" };

            b1.AppendNextBlock(b2);
            b1.AppendNextBlock(b3);

            using (var sw = new StringWriter())
            {
                b1.WriteTo(sw, contextMock.Object);
                Assert.Equal("123", sw.ToString());
            }
        }

        [Fact]
        public void Test_WriteSpaceSuffix()
        {
            var b1 = new DummyWritableBlock() { Content = "1" };
            var b2 = new DummyWritableBlock() { Content = "2" };

            b1.Append(b2);

            b1.WriteWhitespaceSuffix = true;

            using (var sw = new StringWriter())
            {
                b1.WriteTo(sw, contextMock.Object);
                Assert.Equal("1 2", sw.ToString());
            }
        }
    }
}
