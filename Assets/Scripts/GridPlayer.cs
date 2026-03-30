using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public enum PlayerType
{
    Cross,
    Circle
}
public class GridPlayer : NetworkBehaviour
{
    [SerializeField] private int x;
    [SerializeField] private int y;
    public NetworkVariable<bool> isClicked = new  NetworkVariable<bool>();
    private Button gridbtn;
    private Image gridimg;
    private void Awake()
    {
        gridbtn = GetComponent<Button>();
        gridimg = GetComponent<Image>();
        gridimg.color = new Color(1, 1, 1, 0);
    }

    private void Start()
    {
        gridbtn.onClick.AddListener(() =>
        {
            if (GridMgr.Instance.canPlay() && !isClicked.Value)
            {
                
                PlayServerRpc();
                
            }
                
        });
    } 
    [Rpc(SendTo.Server)]
    private void PlayServerRpc()
    {
        // ulong clientId = rpcParams.Receive.SenderClientId;
        // PlayerType requesterType = clientId == 0 ? PlayerType.Circle : PlayerType.Cross;
        //
        // if (GridMgr.Instance.currentplayertype.Value != requesterType || isClicked)
        //     return;
        // if (GridMgr.Instance.canPlay() && !isClicked)
        // {
        //     Debug.Log("Play Grid");
        //     PlayerType playertype = GridMgr.Instance.currentplayertype.Value;
        //     ChangeSpriteRpc(playertype);
        // }
        isClicked.Value = true;
        ChangeSpriteRpc();
    }
    [Rpc(SendTo.Everyone)]
    private void ChangeSpriteRpc()
    {
        PlayerType playertype = GridMgr.Instance.currentplayertype.Value;
        gridimg.color = new Color(1, 1, 1, 1);
        if (playertype == PlayerType.Cross)
        {
            gridimg.sprite = GridMgr.Instance.cross;
        }
        else
        {
            gridimg.sprite =GridMgr.Instance.circle;
        }

        if (IsServer)
        {
            GridMgr.Instance.ChangePlayerRpc();
        }
        
    }
    
    public void ResetGrid()
    {
        isClicked.Value = false;
        gridimg.sprite = null;
    }
}
