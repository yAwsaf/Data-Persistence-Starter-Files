using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private PlayerDataManager playerDataManager;
    public TMP_InputField nameField;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI BestScore;

    private Player player;

    public void Start()
    {
        playerDataManager = GameObject.Find("PlayerDataManager").GetComponent<PlayerDataManager>();
        player = playerDataManager.LoadPlayerData();
        if(player != null)
        {
            Name.text = "Name: " + player.name;
            BestScore.text = "BestScore: " + player.score;
        }
        else
        {
            player = new Player("", 0);
            Name.text = "Name: " + player.name;
            BestScore.text = "BestScore: " + player.score;
        }

    }

    private void SaveData()
    {
        player.name = nameField.text;
    }

    public void StartGame()
    {
        SaveData();
        playerDataManager.SavePlayerData(player);
        SceneManager.LoadScene("main");
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  
        #else
        Application.Quit();  
        #endif
    }
}
