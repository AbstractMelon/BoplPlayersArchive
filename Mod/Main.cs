using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.SceneManagement;

namespace BoplMorePlayers
{
    [BepInPlugin("com.BRT.ExtraPlayers", "Extra Players", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private const int NewMaxPlayers = 15;
        public static ManualLogSource logger;
        private static Harmony harmony;
        private void Awake()
        {
            logger = Logger;

            // Plugin startup logic
            Logger.LogInfo($"You now get more players!");

            harmony = new("com.BRT.MorePlayers");

            harmony.PatchAll();

            // Initilize Stuff
            PlayersConfig.InitializeConfig();
        }
        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        private void Update()
        {
        }

        [HarmonyPatch(typeof(Constants))]
        [HarmonyPatch("MAX_PLAYERS")]
        class Patch
        {
            static void Postfix(ref int __result)
            {
                __result = NewMaxPlayers;
            }

            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                for (int i = 0; i < code.Count; i++)
                {
                    if (code[i].opcode == OpCodes.Ldsfld && ((FieldInfo)code[i].operand).Name == "MAX_PLAYERS")
                    {
                        code[i] = new CodeInstruction(OpCodes.Ldc_I4, NewMaxPlayers);
                    }
                }
                return code;
            }
        }
    }

    public class Functions
    {
        public void RemoveSelf()
        {

        }

    }
}