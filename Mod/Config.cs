using BepInEx.Configuration;
using BepInEx;

namespace BoplMorePlayers
{
    public class PlayersConfig
    {
        public static ConfigEntry<int> SomeIntegerSetting { get; private set; }
        public static ConfigFile config;

        public static void InitializeConfig()
        {
            config = new ConfigFile("moreplayers.cfg", true);

            SomeIntegerSetting = config.Bind("General", "Amount of players", 15, "How many players you want.");
        }
    }
}
