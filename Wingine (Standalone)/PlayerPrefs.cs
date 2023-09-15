using System.Collections.Generic;
using System.IO;

namespace Wingine
{
    public static class PlayerPrefs
    {
        private static Dictionary<string, object> playerPrefsData = new Dictionary<string, object>();

        static PlayerPrefs()
        {
            LoadFromFile();
        }

        public static void SetInt(string key, int value)
        {
            playerPrefsData[key] = value;
            SaveToFile();
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            if (playerPrefsData.ContainsKey(key))
            {
                return (int)playerPrefsData[key];
            }
            return defaultValue;
        }

        public static void SetFloat(string key, float value)
        {
            playerPrefsData[key] = value;
            SaveToFile();
        }

        public static float GetFloat(string key, float defaultValue = 0f)
        {
            if (playerPrefsData.ContainsKey(key))
            {
                return (float)playerPrefsData[key];
            }
            return defaultValue;
        }

        public static void SetString(string key, string value)
        {
            playerPrefsData[key] = value;
            SaveToFile();
        }

        public static string GetString(string key, string defaultValue = "")
        {
            if (playerPrefsData.ContainsKey(key))
            {
                return (string)playerPrefsData[key];
            }
            return defaultValue;
        }

        public static void DeleteKey(string key)
        {
            if (playerPrefsData.ContainsKey(key))
            {
                playerPrefsData.Remove(key);
                SaveToFile();
            }
        }

        public static void DeleteAll()
        {
            playerPrefsData.Clear();
            SaveToFile();
        }

        public static void SaveToFile()
        {
            Directory.CreateDirectory($"./data/{Runner.CurrentProject.Item2}");
            File.Create($"./data/{Runner.CurrentProject.Item2}/2c4b0c332jj3l24j234.ppref").Close();
            DataStore.WriteToBinaryFile<Dictionary<string, object>>($"./data/{Runner.CurrentProject.Item2}/2c4b0c332jj3l24j234.ppref", playerPrefsData);
        }

        public static void LoadFromFile()
        {
            try
            {
                playerPrefsData = DataStore.ReadFromBinaryFile<Dictionary<string, object>>($"./data/{Runner.CurrentProject.Item2}/2c4b0c332jj3l24j234.ppref");
            }
            catch { }

            if (playerPrefsData == null)
            {
                playerPrefsData = new Dictionary<string, object>();
            }
        }
    }
}
