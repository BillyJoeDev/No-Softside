// Reference: 0Harmony
using Harmony;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("No Softside", "Billy Joe", "1.0.0")]
    [Description("Removes soft sides on objects.")]

    public class NoSoftside : CovalencePlugin
    {
        #region Defines
        private static HarmonyInstance _harmony;
        #endregion

        #region Hooks
        private void Loaded()
        {
            if (_harmony == null) _harmony = HarmonyInstance.Create("com.BillyJoe.NoSoftside");
            _harmony.Patch(AccessTools.Method(typeof(DirectionProperties), "IsWeakspot"), new HarmonyMethod(typeof(WeakspotOveride), "Prefix"));
        }

        private void Unload() => _harmony.UnpatchAll("com.BillyJoe.NoSoftside");
        #endregion

        #region Patches
        private static class WeakspotOveride
        {
            internal static bool Prefix(ref bool __result)
            {
                __result = false;
                return false;
            }
        }
        #endregion
    }
}
