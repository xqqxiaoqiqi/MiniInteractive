using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountinuePanel : MonoBehaviour
{
    Button countinuebutton;
    private void Awake()
    {
        countinuebutton = gameObject.GetComponentInChildren<Button>();
        countinuebutton.onClick.AddListener(Onclick);
    }
    private void Onclick()
    {
        ConvSet.Instance().CountinueProcess();
        ConvSet.Instance().ConvPanel.GetComponent<ConvPanel>().PanelOnclick();
    }
}
