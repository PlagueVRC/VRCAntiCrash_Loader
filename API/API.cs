using MelonLoader;
using System.Collections;

namespace VRCAntiCrash_Loader.API
{
    public static class Coroutines
    {
        public static void Start(IEnumerator routine)
        {
            MelonCoroutines.Start(routine);
        }
    }

    public static class Prefs
    {
        public static bool WritePref<T>(string name, T value)
        {
            if (string.IsNullOrEmpty(name) || value == null)
            {
                return false;
            }

            MelonPreferences.CreateCategory("VRCAntiCrash", "VRCAntiCrash");

            MelonPreferences.SetEntryValue<T>("VRCAntiCrash", name, value);

            return false;
        }

        public static T ReadPref<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return default(T);
            }

            if (!MelonPreferences.HasEntry("VRCAntiCrash", name))
            {
                return default(T);
            }

            return MelonPreferences.GetEntryValue<T>("VRCAntiCrash", name);
        }
    }

    public static class VRCAntiLogger
    {
        public static void Log(LogType type = LogType.Log, string text = "{Empty}")
        {
            switch (type)
            {
                case LogType.Log:
                    MelonLogger.Msg(text);
                    break;
                case LogType.Warning:
                    MelonLogger.Warning(text);
                    break;
                case LogType.Error:
                    MelonLogger.Error(text);
                    break;
            }
        }

        public enum LogType
        {
            Log,
            Warning,
            Error
        }
    }
}
