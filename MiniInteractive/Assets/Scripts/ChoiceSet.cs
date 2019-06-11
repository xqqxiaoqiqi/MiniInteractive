using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSet : UnitySingleton<ChoiceSet>
{
    private string ChoicePanelPath = "GamePrefabs/ChoicePanel";
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
        choicepanel.GetComponent<CanvasGroup>().alpha = 1;
        choicepanel.GetComponent<CanvasGroup>().interactable = true;
        choicepanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    public void HideChoicePanel()
    {
        choicepanel.GetComponent<CanvasGroup>().alpha = 0;
        choicepanel.GetComponent<CanvasGroup>().interactable = false;
        choicepanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        choicestext.Clear();
        choiceresult.Clear();
        ConvSet.Instance().paneltype = PanelType.Showing;
    }

}
