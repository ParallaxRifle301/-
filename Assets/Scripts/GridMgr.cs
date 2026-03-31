using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GridMgr:NetworkBehaviour
{
    private static GridMgr instance;
    public static GridMgr Instance => instance;

    private void Awake()
    {
        instance = this;
        Onint();
    }
    public Sprite circle;
    public Sprite cross;
    public NetworkVariable<PlayerType> currentplayertype=new NetworkVariable<PlayerType>();
    public PlayerType localplayertype;
    
    private void Onint()
    {
        circle = Resources.Load<Sprite>("Textures/Circle");
        cross = Resources.Load<Sprite>("Textures/Cross");
    }

    public override void OnNetworkSpawn()
    {
        // Debug.Log("OnNetworkSpawn");
        // if (NetworkManager.Singleton.LocalClientId==0)
        // {
        //     Debug.Log("OnNetworkSpawn");
        //     currentplayertype.Value = PlayerType.Circle;
        // }
        // else
        // {
        //     Debug.Log("OnNetworkSpawn");
        //     currentplayertype.Value = PlayerType.Cross;
        // }
        // Debug.Log("OnNetworkSpawn");
        if (IsClient)
        {
            localplayertype = 
                NetworkManager.Singleton.LocalClientId==0?PlayerType.Cross: PlayerType.Circle;
        }

        if (IsServer)
        {
            currentplayertype.Value = localplayertype;
        }
        
    }
    
    public bool canPlay()
    {
        return currentplayertype.Value == localplayertype;
    }
    [Rpc(SendTo.Server)]
    public void ChangePlayerRpc()
    {
        if (IsServer)
        {
            if (currentplayertype.Value == PlayerType.Cross)
            {
                currentplayertype.Value = PlayerType.Circle;
            }
            else
            {
                currentplayertype.Value = PlayerType.Cross;
            }
            PlayerScoreView.Instance.SetActiveRpc(currentplayertype.Value);
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
