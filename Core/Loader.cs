using MelonLoader;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VRCAntiCrash_Loader.Types;

using Assembly = System.Reflection.Assembly;

namespace VRCAntiCrash_Loader
{
    public class Loader : MelonMod
    {
        internal static VRCAntiCrash VRCAnti = null;

        #region Overrides
        public override void OnApplicationStart()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\Mods\\VRCAntiCrash.dll"))
            {
                File.Delete(Environment.CurrentDirectory + "\\Mods\\VRCAntiCrash.dll");
            }

            Networking.Networking.Initiate();

            VRCAnti?.OnApplicationStart();
        }

        #region Misc Overrides
        public override void OnApplicationQuit()
        {
            VRCAnti?.OnApplicationQuit();
        }

        public override void OnFixedUpdate()
        {
            VRCAnti?.OnFixedUpdate();
        }

        public override void OnGUI()
        {
            VRCAnti?.OnGUI();
        }

        public override void OnLateUpdate()
        {
            VRCAnti?.OnLateUpdate();
        }

        public override void OnLevelWasInitialized(int level)
        {
            VRCAnti?.OnLevelWasInitialized(level);
        }

        public override void OnLevelWasLoaded(int level)
        {
            VRCAnti?.OnLevelWasLoaded(level);
        }

        public override void OnModSettingsApplied()
        {
            VRCAnti?.OnModSettingsApplied();
        }

        public override void OnUpdate()
        {
            VRCAnti?.OnUpdate();
        }

        public override void VRChat_OnUiManagerInit()
        {
            VRCAnti?.VRChat_OnUiManagerInit();
        }
        #endregion
        #endregion
    }
}
