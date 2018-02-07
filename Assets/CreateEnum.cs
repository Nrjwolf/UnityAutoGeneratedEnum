#if UNITY_EDITOR
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEditor;

public class CreateEnum
{
    [System.Serializable]
    public class EnumClass
    {
        public EnumClass(List<string> names, string name)
        {
            this.names = names;
            this.name = name;
        }

        public string name;
        public List<string> names = new List<string>();
    }

    public static void CreateEnumsInFile(string fliepath, params EnumClass[] enums)
    {
        using (StreamWriter streamWriter = new StreamWriter(fliepath))
        {
            foreach (var e in enums)
            {
                AddEnum(streamWriter, e.names, e.name);
            }
        }

        // Компиляция
        AssetDatabase.Refresh();
    }

    private static void AddEnum(StreamWriter streamWriter, List<string> list, string emunName)
    {
        streamWriter.WriteLine("public enum " + emunName);
        streamWriter.WriteLine("{");
        for (int i = 0; i < list.Count; i++)
        {
            streamWriter.WriteLine("\t" + list[i] + ",");
        }
        streamWriter.WriteLine("}");
        streamWriter.WriteLine("");
    }
}
#endif
