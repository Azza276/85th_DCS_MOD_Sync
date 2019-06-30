using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCS_Mod_Sync_App.Config
{
    public class Settings
    {
        public bool AutodetectModsFolder { get; set; } = true;
        public string ModsFolderOverride { get; set; } = "";

        public bool AutodetectLiveriesFolder { get; set; } = true;
        public string LiveriesFolderOverride { get; set; } = "";

        public int DownloadThreads { get; set; } = 4;

        public bool AutomaticallyDownloadAfterVerification { get; set; } = false;
        public bool AutomaticallyBuildLinksAfterDownload { get; set; } = true;

        public bool AutodetectAppFolder { get; set; } = true;
        public string AppFolderOverride { get; set; } = "";
        public static Settings LoadFromFile(string filename)
        {
            Settings result;

            JsonSerializerSettings serialiserSettings = new JsonSerializerSettings();
            serialiserSettings.NullValueHandling = NullValueHandling.Ignore;
            if (File.Exists(filename))
            {
                string content = File.ReadAllText(filename);
                result = JsonConvert.DeserializeObject<Settings>(content, serialiserSettings);
            }
            else
            {
                result = new Settings();
            }

            return result;
        }

        public static void SaveToFile(string filename, Settings settings)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented })
            {
                serializer.Serialize(writer, settings);
            }
        }
    }
}
