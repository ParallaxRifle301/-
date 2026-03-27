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
    public bool isClicked = false;
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
            PlayRpc();
        });
    } 
    [Rpc(SendTo.Everyone)]
    private void PlayRpc()
    {
        PlayerType playertype = GridMgr.Instance.playertype;
        if (!isClicked)
        {
            gridimg.color = new Color(1, 1, 1, 1);
            if (playertype == PlayerType.Cross)
            {
                gridimg.sprite = GridMgr.Instance.cross;
            }
            else
            {
                gridimg.sprite =GridMgr.Instance.circle;
            }
            isClicked = true;
            GridMgr.Instance.ChangePlayer();
        }
    }
    public void ResetGrid()
    {
        isClicked = false;
        gridimg.sprite = null;
    }
}
