using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GridMgr 
{
    private static GridMgr instance;
    public static GridMgr Instance
    {
        get
        {
            if (instance == null)
                instance = new GridMgr();
            return instance;
        }
    }

    private GridMgr()
    {
        Onint();
    }
    public Sprite circle;
    public Sprite cross;
    public PlayerType playertype;
    private void Onint()
    {
        
        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Client started");
        }
        else
        {
            Debug.Log("Client stopped");
        }
        
        circle = Resources.Load<Sprite>("Textures/Circle");
        cross = Resources.Load<Sprite>("Textures/Cross");
    }

    public void ChangePlayer()
    {
        if (playertype == PlayerType.Cross)
        {
            playertype = PlayerType.Circle;
        }
        else
        {
            playertype = PlayerType.Cross;
        }
        
    }
    
    public List<GridPlayer> players=new List<GridPlayer>();
    public void ResetGrid()
    {
        foreach (GridPlayer player in players)
        {
            player.ResetGrid();
        }
    }
}
