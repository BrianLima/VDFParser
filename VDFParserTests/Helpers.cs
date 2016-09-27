using System.IO;
using System.Reflection;

namespace VDFParserTests {
    public static class Helpers {
        public static Stream GetResourceNamed(string name) {
            var asm = Assembly.GetExecutingAssembly();
            return asm.GetManifestResourceStream(string.Format("VDFParserTests.Resources.{0}", name));
        }
    }
}
