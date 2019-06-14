using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitlePanel : MonoBehaviour
{
    private Button startbutton;
    private GameObject Main;
    public ConvPanel convpanel;
    public GameObject conv;
    private void Awake()
    {
        startbutton = GameObject.Find("StartButton").GetComponent<Button>();
        startbutton.onClick.AddListener(StartGame);
        Main = GameObject.Find("MainCanva");
    }
    private void StartGame()
    {
        LevelManager.HidePanel(gameObject);
        ImageSet.Instance().UpdateBustPanel("Vilmaris_usual");
        ImageSet.Instance().UpdateBackgroundPanel("Gate");
        LevelManager.ShowPanel(Main);
        LevelManager.ShowPanel(conv);
        convpanel.PanelOnclick();
    }
}
