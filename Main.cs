using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine.SceneManagement;

namespace BoplMorePlayers
{
    [BepInPlugin("com.BRT.MorePlayers", "More Players", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        public static ManualLogSource logger;
        private static Harmony harmony;
        private void Awake()
        {
            logger = base.Logger;

            // Plugin startup logic
            Logger.LogInfo($"You now get more players!");

            harmony = new("com.BRT.MorePlayers");
        }
        private void OnDestroy(Functions functions)
        {
            harmony.UnpatchSelf();
            functions.RemoveSelf();
        }

        private void Update()
        {
        }
    }

    public class Functions
    {
        public void RemoveSelf()
        {

        }

    }
}