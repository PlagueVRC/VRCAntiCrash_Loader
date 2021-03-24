using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Harmony;

namespace VRCAntiCrash_Loader.Types
{
    public class VRCAntiCrash
    {
        private string Astro5 = "Astro Is A Skid5";

        public virtual void OnApplicationStart() { }
        public virtual void OnApplicationQuit() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnGUI() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnLevelWasInitialized(int level) { }
        public virtual void OnLevelWasLoaded(int level) { }
        public virtual void OnModSettingsApplied() { }
        public virtual void OnUpdate() { }
        public virtual void VRChat_OnUiManagerInit() { }
    }
}
