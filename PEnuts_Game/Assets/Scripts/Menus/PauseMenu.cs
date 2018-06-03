using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public partial class PauseMenu : MonoBehaviour
{

    private GameObject multi;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUi;

/*
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
    }

    public void Disconnect()
    {
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0,
            networkManager.OnDropConnection);
        networkManager.StopHost();
    }
*/    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(string Menu)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Menu);
        NetworkManager.Shutdown();
        multi.SetActive(false);
        /*
        MatchInfo matchInfo = networkManager.matchInfo;
        networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0,
            networkManager.OnDropConnection);
        networkManager.StopHost();
         */
    }
    
    
    public void Quit()
    {
        Application.Quit();
    }
}
