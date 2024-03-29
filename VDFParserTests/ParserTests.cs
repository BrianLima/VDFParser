﻿using NUnit.Framework;
using VDFParser.Models;
using System;

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
                    appid = 123456,
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

                Assert.AreEqual(exp.Index, par.Index);
                Assert.AreEqual(exp.appid, par.appid);
                Assert.AreEqual(exp.AppName, par.AppName);
                Assert.AreEqual(exp.Exe, par.Exe);
                Assert.AreEqual(exp.StartDir, par.StartDir);
                Assert.AreEqual(exp.Icon, par.Icon);
                Assert.AreEqual(exp.ShortcutPath, par.ShortcutPath);
                Assert.AreEqual(exp.LaunchOptions, par.LaunchOptions);
                Assert.AreEqual(exp.IsHidden, par.IsHidden);
                Assert.AreEqual(exp.AllowDesktopConfig, par.AllowDesktopConfig);
                Assert.AreEqual(exp.AllowOverlay, par.AllowOverlay);
                Assert.AreEqual(exp.OpenVR, par.OpenVR);
                Assert.AreEqual(exp.Devkit, par.Devkit);
                Assert.AreEqual(exp.DevkitGameID, par.DevkitGameID);
                Assert.AreEqual(exp.LastPlayTime, par.LastPlayTime);
                Assert.AreEqual(exp.Tags, par.Tags);
            }
        }
    }
}
