using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int score=0;
    [SerializeField]private PlayerType playertype;
    public bool isthis;
    public Text text;
    public Text thisText;
    public void Win()
    {
        score++;
        text.text = score.ToString();
    }
    public void ChangePlayer()
    {
        thisText.gameObject.SetActive(true);   
    }
    
}
