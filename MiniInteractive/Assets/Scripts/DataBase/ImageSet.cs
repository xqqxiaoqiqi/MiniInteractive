using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSet : UnitySingleton<ImageSet>
{
    private string BustPath = "img/busts/";
    private string BackgroundPath = "img/backgrounds/";
    private GameObject BackgroundPanel;
    private GameObject BustPanel;
    private void Awake()
    {
        BustPanel = GameObject.Find("BustPanel");
        BackgroundPanel = GameObject.Find("BackgroundPanel");
    }
    public void UpdateBustPanel(string name)
    {
        BustPanel.GetComponent<Image>().sprite = (Sprite)Resources.Load(BustPath + name,typeof(Sprite));
    }
    public void UpdateBackgroundPanel(string name)
    {
        BackgroundPanel.GetComponent<Image>().sprite = (Sprite)Resources.Load(BackgroundPath + name,typeof(Sprite));
    }
}
