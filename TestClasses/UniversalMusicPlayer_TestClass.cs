using OpenQA.Selenium;
using GK_Assessment.Utilities;
using OpenQA.Selenium.Appium;
using System;

namespace GK_Assessment.TestClasses
{
    class UniversalMusicPlayer_TestClass
    {
        //Page Objects:
        private static By GenresOption = By.XPath("//android.widget.TextView[@text=\"Genres\"]");
        private static By RockOption = By.XPath("//android.widget.TextView[@text=\"Rock\"]");
        private static By HeySailorSong = By.XPath("//android.widget.TextView[@text=\"Hey Sailor\"]");
        private static By MusicPlayerMinimized = By.Id("com.example.android.uamp:id/fragment_playback_controls");

        public static void NavigateToRockCatgory()
        {
            try
            {
                Driver_Utilities.ClickElement(GenresOption);
                Driver_Utilities.ClickElement(RockOption);

                Console.WriteLine("Navigated to the \"Rock\" category.");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR]:\n" + e.Message);
                throw e;
            }
        }

        public static void ClickOnSongOption(string SongName)
        {
            try
            {
                Driver_Utilities.ClickElement(By.XPath("//android.widget.TextView[@text=\"" + SongName + "\"]"));

                Console.WriteLine("Clicked on the song \"" + SongName + "\"");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR]:\n" + e.Message);
                throw e;
            }
        }

        public static void OpenMusicPlayer()
        {
            try
            {
                Driver_Utilities.ClickElement(MusicPlayerMinimized);

                Console.Write("Opened the music player");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR]:\n" + e.Message);
                throw e;
            }
        }

        public static void ValidateSongLength(string SongTime)
        {
            try
            {
                OpenMusicPlayer();
                Driver_Utilities.ValidateElementExists(By.XPath("//android.widget.TextView[@text=\"" + SongTime.Trim() + "\"]"));

                Console.WriteLine("Validated the currently playing song length is: " + SongTime);
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR]:\n" + e.Message);
                throw e;
            }
        }
    }
}
