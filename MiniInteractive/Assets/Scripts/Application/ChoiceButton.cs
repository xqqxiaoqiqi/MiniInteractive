using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    private Button thisbutton;
    private GameObject choicepanel;
    void Awake()
    {
       choicepanel = GetComponentInParent<ChoicePanel>().gameObject;
       thisbutton = GetComponent<Button>();
       thisbutton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (ChoicePanel.buttonlist.ContainsKey(thisbutton))
        {
            LevelManager.Instance().GetGameFlow(ChoicePanel.buttonlist[thisbutton]);
        }
        ChoiceSet.Instance().HideChoicePanel();
    }
}
