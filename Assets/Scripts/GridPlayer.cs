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
    private NetworkObject networkObject;
    private void Awake()
    {
        gridbtn = GetComponent<Button>();
        gridimg = GetComponent<Image>();
        networkObject=GetComponent<NetworkObject>();
        gridimg.color = new Color(1, 1, 1, 0);
    }
    private void Start()
    {
        networkObject.Spawn(true);
        Debug.Log("wadih");
        gridbtn.onClick.AddListener(() =>
        {
            Play();
            
        });
    }
    private void Play()
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
        }
    }
    public void ResetGrid()
    {
        isClicked = false;
        gridimg.sprite = null;
    }
}
