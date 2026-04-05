using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreView :NetworkBehaviour,INetworkSpawnInit
{
    private static PlayerScoreView instance;
    public static PlayerScoreView Instance => instance;
    private void Awake()
    {
        instance = this;
    }

    public Text CrossTxt;
    public Text CrossNme;
    public Image CrossImg;
    public Text CircleTxt;
    public Text CircleNme;
    public Image CircleImg;
    private PlayerScoreController playerScoreController;

    private void Start()
    {
        
    }
    public void UpdatePlayerText()
    {
    }
    [Rpc(SendTo.Everyone)]
    public void SetActiveRpc(PlayerType playerType)
    {
        if(playerType==PlayerType.Circle)
        {
            CircleImg.gameObject.SetActive(true);
            CrossImg.gameObject.SetActive(false);
        }
        else
        {
            CircleImg.gameObject.SetActive(false);
            CrossImg.gameObject.SetActive(true);
        }
    }

    public void INetworkSpawnInit()
    {
        if (GridMgr.Instance.localplayertype == PlayerType.Circle)
        {
            CrossNme.gameObject.SetActive(false);
        }
        else
        {
            CircleNme.gameObject.SetActive(false);
        }
    }
}
public class PlayerScoreData
{
    public int CrossScore;
    public int CircleScore;
}
