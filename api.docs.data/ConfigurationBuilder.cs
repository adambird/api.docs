using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NHibernate.Cfg;

namespace api.docs.data
{
    internal class ConfigurationBuilder
    {
        private const string SerializedCfg = "configuration.bin";

        public Configuration Build()
        {
            var cfg = LoadConfigurationFromFile();
            if (cfg == null)
            {
                cfg = new Configuration().Configure();
                SaveConfigurationToFile(cfg);
            }
            return cfg;
        }

        private Configuration LoadConfigurationFromFile()
        {
            if (!IsConfigurationFileValid()) return null;

            try
            {
                using (var file = File.Open(SerializedCfg, FileMode.Open))
                {
                    var bf = new BinaryFormatter();
                    return bf.Deserialize(file) as Configuration;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool IsConfigurationFileValid()
        {
            if (!File.Exists(SerializedCfg)) return false;

            var configInfo = new FileInfo(SerializedCfg);
            var asm = Assembly.GetExecutingAssembly();

            if (asm.Location == null) return false;

            // if assembly is newer then config is stale
            var asmInfo = new FileInfo(asm.Location);
            if (asmInfo.LastWriteTime > configInfo.LastWriteTime) return false;

            // if app.config is newer then conig is stale
            var appDomain = AppDomain.CurrentDomain;
            var appConfigPath = appDomain.SetupInformation.ConfigurationFile;
            var appConfigInfo = new FileInfo(appConfigPath);
            if (appConfigInfo.LastWriteTime > configInfo.LastWriteTime) return false;

            // it's still fresh
            return true;
        }

        private void SaveConfigurationToFile(Configuration cfg)
        {
            using (var file = File.Open(SerializedCfg, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(file, cfg);
            }
        }
    }
}
