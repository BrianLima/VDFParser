using VDFParser;
using VDFParser.Models;
using NUnit.Framework;
using System.IO;

namespace VDFParserTests {
    [TestFixture]
    public class SerializerTests {
        [Test]
        public void TestSerialization() {
            Stream originalDataStream = Helpers.GetResourceNamed("shortcuts.vdf");
            byte[] originalData = new byte[originalDataStream.Length];
            originalDataStream.Read(originalData, 0, (int)originalDataStream.Length);
            originalDataStream.Seek(0, SeekOrigin.Begin);
            var entries = VDFParser.VDFParser.Parse(originalDataStream);
            byte[] serializedData = VDFSerializer.Serialize(entries);
            Assert.AreEqual(originalData, serializedData);
        }

        [Test]
        public void TestUTF8Serialization() {
            Stream originalDataStream = Helpers.GetResourceNamed("shortcuts_utf8.vdf");
            byte[] originalData = new byte[originalDataStream.Length];
            originalDataStream.Read(originalData, 0, (int)originalDataStream.Length);
            originalDataStream.Seek(0, SeekOrigin.Begin);
            var entries = VDFParser.VDFParser.Parse(originalDataStream);
            byte[] serializedData = VDFSerializer.Serialize(entries);
            Assert.AreEqual(originalData, serializedData);
        }
    }
}
