using NUnit.Framework;
using VDFParser.Models;
using System;
using NUnit.Framework.Legacy;

namespace VDFParserTests {
    [TestFixture]
    public class ParserTests {

        [Test]
        public void TestParserBehaviour() {
            var subjects = new string[] { "shortcuts", "shortcuts4" };
            foreach(var subject in subjects) {
                VDFParser.VDFParser.Parse(Helpers.GetResourceNamed(string.Format("{0}.vdf", subject)));
            }

            Assert.Throws<VDFParser.VDFTooShortException>(() => VDFParser.VDFParser.Parse(Helpers.GetResourceNamed("shortcuts2.vdf")));
        }

        [Test]
        public void TestParsedContents() {
            var expectations = new VDFEntry[] {
                new VDFEntry() {
                    appid = 875770417,
                    AppName = "Guitar Hero World Tour",
                    Exe = "\"D:\\Program Files\\GH\\GHWT.exe\"",
                    StartDir = "\"D:\\Program Files\\GH\\\"",
                    Icon = "",
                    ShortcutPath = "",
                    LaunchOptions = "",
                    IsHidden = 0,
                    AllowDesktopConfig = 1,
                    AllowOverlay = 1,
                    OpenVR = 0,
                    Devkit = 0,
                    DevkitGameID = "",
                    LastPlayTime = 1590640610,
                    Tags = new string[] { "Music" },
                    Index = 0
                }
            };
            var entries = VDFParser.VDFParser.Parse(Helpers.GetResourceNamed("shortcuts.vdf"));
            for(var i = 0; i < expectations.Length; i++) {
                var exp = expectations[i];
                var par = entries[i];

                ClassicAssert.AreEqual(exp.Index, par.Index);
                ClassicAssert.AreEqual(exp.appid, par.appid);
                ClassicAssert.AreEqual(exp.AppName, par.AppName);
                ClassicAssert.AreEqual(exp.Exe, par.Exe);
                ClassicAssert.AreEqual(exp.StartDir, par.StartDir);
                ClassicAssert.AreEqual(exp.Icon, par.Icon);
                ClassicAssert.AreEqual(exp.ShortcutPath, par.ShortcutPath);
                ClassicAssert.AreEqual(exp.LaunchOptions, par.LaunchOptions);
                ClassicAssert.AreEqual(exp.IsHidden, par.IsHidden);
                ClassicAssert.AreEqual(exp.AllowDesktopConfig, par.AllowDesktopConfig);
                ClassicAssert.AreEqual(exp.AllowOverlay, par.AllowOverlay);
                ClassicAssert.AreEqual(exp.OpenVR, par.OpenVR);
                ClassicAssert.AreEqual(exp.Devkit, par.Devkit);
                ClassicAssert.AreEqual(exp.DevkitGameID, par.DevkitGameID);
                ClassicAssert.AreEqual(exp.LastPlayTime, par.LastPlayTime);
                ClassicAssert.AreEqual(exp.Tags, par.Tags);
            }
        }
    }
}
