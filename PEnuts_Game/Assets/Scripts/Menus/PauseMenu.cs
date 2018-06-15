using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public partial class PauseMenu : MonoBehaviour
{
    public GameObject hostCanvas;
    public GameObject clientCanvas;

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
    void Start()
    {
        GameIsPaused = false;
    }

    void Update()
    {
        bool ColorMenuActivated = GameObject.Find("ColorSelectMenu").GetComponent<ColorSelectMenu>().ColorMenuActivated;
        if (!ColorMenuActivated)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                    Resume();
                else
                    Pause();
            }

            foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
            {
                NetworkPlayer player = p.GetComponent<NetworkPlayer>();
                if (player.client && player.id == 2)
                {
                    hostCanvas.SetActive(false);
                    clientCanvas.SetActive(true);
                }
                if (player.client && player.id == 1)
                {
                    hostCanvas.SetActive(true);
                    clientCanvas.SetActive(false);
                }
            }
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
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToLevel(string name)
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("NetworkPlayer"))
        {
            NetworkPlayer player = p.GetComponent<NetworkPlayer>();
            if (player.id == 1)
            {
                player.ChangeScene(name);
            }
        }
    }
    
    public void LoadMenu(string Menu)
    {
        GameIsPaused = false;
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
