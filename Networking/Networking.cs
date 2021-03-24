using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

using VRCAntiCrash_Loader.API;
using VRCAntiCrash_Loader.Types;

namespace VRCAntiCrash_Loader.Networking
{
    internal class Networking
    {
        private static WebClient Client = new WebClient();

        private static byte[] Buffer;
        private static Assembly ModAssembly;

        internal static bool Initiate()
        {
            if (ModAssembly != null)
            {
                return true;
            }

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Buffer = Client.DownloadData(Encoding.UTF8.GetString(Convert.FromBase64String("redacted")));

                if (Buffer.Length > 1000)
                {
                    ModAssembly = null;

                    if (Environment.CommandLine.Contains("--VRCAntiCrash_Dev") && File.Exists(Environment.CurrentDirectory + "//Dev//VRCAntiCrash.dll"))
                    {
                        ModAssembly = Assembly.Load(File.ReadAllBytes(Environment.CurrentDirectory + "//Dev//VRCAntiCrash.dll"));
                    }
                    else
                    {
                        ModAssembly = Assembly.Load(Buffer);
                    }

                    if (ModAssembly != null)
                    {
                        foreach (Type type in ModAssembly.GetTypes())
                        {
                            if (type.IsSubclassOf(typeof(VRCAntiCrash)))
                            {
                                Loader.VRCAnti = (VRCAntiCrash)Activator.CreateInstance(type);

                                return true;
                            }
                        }
                    }
                    else
                    {
                        VRCAntiLogger.Log(VRCAntiLogger.LogType.Error, "Failed To Load VRCAntiCrash!");
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                VRCAntiLogger.Log(VRCAntiLogger.LogType.Error, "Failed To Load VRCAntiCrash! - Error: " + ex.Message);

                return false;
            }
        }
    }
}
