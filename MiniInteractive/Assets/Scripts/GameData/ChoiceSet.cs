using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSet : UnitySingleton<ChoiceSet>
{
    private GameObject choicepanel;
    public static List<string> choicestext = new List<string>();
    public static List<string> choiceresult = new List<string>();
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
        choicestext.Clear();
        choiceresult.Clear();
        ConvSet.Instance().paneltype = PanelType.Showing;
    }

}
