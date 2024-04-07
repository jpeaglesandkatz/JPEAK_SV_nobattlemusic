using BepInEx;
using BepInEx.Logging;
using HarmonyLib;



namespace JPEAK_SV_nobattlemusic
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class JPEAK_SV_nobattlemusic : BaseUnityPlugin
    {

        private const string MyGUID = "com.JPEAK_SV_nobattlemusic";
        private const string PluginName = "JPEAK_SV_nobattlemusic";
        private const string VersionString = "1.0.0";
              

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake()
        {

            // Apply all of our patches
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.CreateAndPatchAll(typeof(JPEAK_SV_nobattlemusic), null);

            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");

            Log = Logger;
        }


        [HarmonyPatch(typeof(Music), "PlayBattleMusic")]
        [HarmonyPrefix]
        static bool PlayBattleMusic_pre(ref bool __runOriginal) 
        {
            __runOriginal = false;
            return false;
        }
              

    }

}



