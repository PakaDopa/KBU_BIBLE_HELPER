using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class Converter
    {
        public static T StringToEnum<T>(string str)
        {
            if (str == "")
                return default;
            return (T)Enum.Parse(typeof(T), str);
        }
        public static T GetResource<T>(string path) where T : UnityEngine.Object
        {
            if (path.Contains("null"))
                return default(T);
            T resource = Resources.Load<T>(path);
            return resource;
        }
        public static T[] GetResources<T>(string path) where T : UnityEngine.Object
        {
            T[] resources = Resources.LoadAll<T>(path);
            List<T> list = new List<T>();

            for (int i = 0; i < resources.Length; i++)
            {
                try
                {
                    list.Add(resources[i]);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex);
                }
            }

            return list.ToArray();
        }
    }
}