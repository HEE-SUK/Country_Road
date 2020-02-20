using System;
using UnityEngine;
// using QU.Json;

[Serializable]
public abstract class Storage<T> where T : class, new()
{
    private static object lockObject = new object();
    protected static T instance = null;
    
    public static T Load()
    {
        lock (lockObject)
        {
            if (instance == null)
            {
                string storageData = PlayerPrefs.GetString(typeof(T).Name);
                if (string.IsNullOrEmpty(storageData))
                {
                    instance = new T();
                }
                else
                {
                    // instance = JsonConvert.DeserializeObject<T>(storageData);
                }
            }
            return instance;
        }
    }

    protected static void Save()
    {
        // PlayerPrefs.SetString(typeof(T).Name, JsonConvert.SerializeObject(instance));
        string storageData = PlayerPrefs.GetString(typeof(T).Name);
    }

    public static void Reset()
    {
        PlayerPrefs.DeleteKey(typeof(T).Name);
        PlayerPrefs.Save();
    }
}