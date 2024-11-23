using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private string filePath;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/PlayerData.json";
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerData(Player player)
    {
        string json = JsonUtility.ToJson(player);
        File.WriteAllText(filePath, json);
        Debug.Log("DataSaved");
    }
    public Player LoadPlayerData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Player player = JsonUtility.FromJson<Player>(json);
            Debug.Log("DataLoaded");
            return player;
        }
        else
        {
            Debug.Log("NotExitFile");
            return null;
        }

    }

}
