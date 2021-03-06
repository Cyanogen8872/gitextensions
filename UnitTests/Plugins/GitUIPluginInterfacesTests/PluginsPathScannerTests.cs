﻿using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using GitUIPluginInterfaces;
using NUnit.Framework;

namespace GitUIPluginInterfacesTests
{
    [TestFixture]
    public class PluginsPathScannerTests
    {
        [TestCase(@"..\..\PathScanningData", "PluginInRootDir.dll", "PluginInOwnDir.dll")]
        public void PathScanning(string userPluginsPath, params string[] expectedFileNames)
        {
            var pluginFiles = PluginsPathScanner.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userPluginsPath));

            pluginFiles.Should().HaveCount(expectedFileNames.Length);
            pluginFiles.Select(f => f.Name).Should().Contain(expectedFileNames);
        }
    }
}
