using GK_Assessment.TestClasses;
using GK_Assessment.Utilities;
using NUnit.Framework;
using System;
using System.Data;

namespace GK_Assessment.UnitTests
{
    class MobileAutomation_Test
    {
        [SetUp]
        public void Setup()
        {
            Driver_Utilities.CreateAndroidDriver("R58N2255B3M", "10");
        }

        /**
        This test will perform the following objectives:
        1. Open the Universal Music Player application
        2. Open the Genres, Rock category.
        3. Play the song "Hey Sailor".
        4. Open the currently playing song.
        5. Confirm the song "Hey Sailor" is 03:13 in length.
        **/

        [Test]
        public void MobileAutomationScenario()
        {
            UniversalMusicPlayer_TestClass.NavigateToRockCatgory();
            UniversalMusicPlayer_TestClass.ClickOnSongOption("Hey Sailor");
            UniversalMusicPlayer_TestClass.ValidateSongLength("03:13");
        }

        [TearDown]
        public void TearDown()
        {
            Driver_Utilities.ShutdownDriver();
        }
    }
}
