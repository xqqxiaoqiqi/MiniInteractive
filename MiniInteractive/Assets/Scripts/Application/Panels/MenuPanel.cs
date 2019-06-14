using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public GameObject titlepanel;
    public GameObject mainpanel;
    public GameObject choicepanel;
    public GameObject tooldetailpanel;
    public GameObject countinuepanel;
    public GameObject buttonpanel;
    void Start()
    {
        
    }
    public void BackToTitle()
    {
        LevelManager.HidePanel(choicepanel);
        LevelManager.HidePanel(tooldetailpanel);
        LevelManager.HidePanel(countinuepanel);
        LevelManager.HidePanel(mainpanel);
        LevelManager.ShowPanel(titlepanel);
        LevelManager.HidePanel(buttonpanel);
        GameData.BeZero();
        LevelManager.Instance().GetGameFlow("0_1");
    }

}
