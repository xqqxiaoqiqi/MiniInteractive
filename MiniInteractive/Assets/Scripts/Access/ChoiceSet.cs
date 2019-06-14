using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSet : UnitySingleton<ChoiceSet>
{
    private GameObject choicepanel;
    private void Awake()
    {
        choicepanel = GameObject.Find("ChoicePanel");
    }
    public void ShowChoicePanel()
    {
        choicepanel.GetComponent<ChoicePanel>().UpDateChoicePanel();
        LevelManager.ShowPanel(choicepanel);

    }
    public void HideChoicePanel()
    {
        LevelManager.HidePanel(choicepanel);
        GameData.choicestext.Clear();
        GameData.choiceresult.Clear();
        ConvSet.Instance().paneltype = PanelType.Showing;
    }

}
