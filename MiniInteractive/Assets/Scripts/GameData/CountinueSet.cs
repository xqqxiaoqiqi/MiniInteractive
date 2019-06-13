using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountinueSet : UnitySingleton<CountinueSet>
{
    private GameObject CountinuePanel;
    private void Awake()
    {
        CountinuePanel = GameObject.Find("CountinuePanel");
    }
    public void ShowCountinuePanel()
    {
        LevelManager.ShowPanel(CountinuePanel);
    }
    public void HideCountinuePanel()
    {
        LevelManager.ShowPanel(CountinuePanel);
    }

}
