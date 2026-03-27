using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class GameMgr : MonoBehaviour
{
    private static GameMgr instance;
    public static GameMgr Instance;


    public Button serverBtn;
    public Button clientBtn;
    public Button hostBtn;
    public Button shotDownBtn;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        serverBtn.onClick.AddListener(() =>
        {
            if
                (NetworkManager.Singleton.StartServer())
            {
                Debug.Log("Server started");
            }
            else
            {
                Debug.Log("Server stopped");
            }
        });
        clientBtn.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Debug.Log("Client started");
            }
            else
            {
                Debug.Log("Client stopped");
            }
        });
        hostBtn.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {
                Debug.Log("Host started");
            }
            else
            {
                Debug.Log("Host stopped");
            }
        });
        shotDownBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();

        });
    }  
    
    private void Update()
    {
        
    }
}
