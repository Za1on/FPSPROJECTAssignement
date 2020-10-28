using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    
    public Button Restart;
    public Button Quit;
    public Player m_Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(m_Player.enabled == false)
        {
            Restart.gameObject.SetActive(true);
            Quit.gameObject.SetActive(true);
        }
    }
}
