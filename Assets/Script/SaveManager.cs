using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;




//https://www.youtube.com/watch?v=vTSefC03ONc


public static class SaveManager
{
  public static void Save(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.dataPath,"PlayerData.bin");
        FileStream stream = File.Create(path);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static SaveData Load()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.dataPath, "PlayerData.bin");
            FileStream stream = File.OpenRead(path);
            SaveData data = (SaveData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        catch(Exception e)
        {
       


            Debug.Log(e.Message);
            return default;
            
        }
       
    }

}
