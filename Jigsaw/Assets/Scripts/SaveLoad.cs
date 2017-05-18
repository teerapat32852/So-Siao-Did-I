using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
    public static SaveLoad saveLoad;
    public int level;

	// Use this for initialization
	void Awake ()
    {
		if(saveLoad==null)
        {
            DontDestroyOnLoad(saveLoad);
            saveLoad = this;
        }
        else if(saveLoad!=this)
        {
            Destroy(saveLoad);
        }
	}
	public void Save()
    {
        //create formatter and save file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        //create object to save data to
        PlayerData data = new global::PlayerData();
        data.savelevel = level;


        //write the obj to the file and closes it
        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if(File.Exists(Application.persistentDataPath+"/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat",FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            level = data.savelevel;
        }
    }
	
    public void Delete()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            File.Delete(Application.persistentDataPath + "/playerinfo.dat");
        }
    }
}
[Serializable]
class PlayerData
{
    public int savelevel;
}
