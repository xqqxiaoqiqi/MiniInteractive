using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvPanel : MonoBehaviour
{
    private Button convbutton;
    private Text convtext;
    public float charsPerSecond = 0.2f;
    private float timer;
    private int currentPos = 0;
    void Awake()
    {
        convbutton = GetComponent<Button>();
        convtext = GetComponentInChildren<Text>();
        InstalizePanel();
    }
    private void Update()
    {
        TryShowConv();
    }
    private void InstalizePanel()
    {
        convbutton.onClick.AddListener(PanelOnclick);
    }
    private void PanelOnclick()
    {
        switch (ConvSet.Instance().paneltype)
        {
            case PanelType.Ready:
                ConvSet.Instance().paneltype = PanelType.Showing;
                break;
            case PanelType.Showing:
                ConvSet.Instance().paneltype = PanelType.RequestStop;
                break;
            case PanelType.ReadyToChoice:
                ChoiceSet.Instance().ShowChoicePanel();
                break;
            case PanelType.Hide:
                Debug.Log("error!");
                break;
            default:
                break;

        }
    }
    private void TryShowConv()
    {
        switch(ConvSet.Instance().paneltype)
        {
            case PanelType.Showing:
                if (ConvSet.Instance().paneltype == PanelType.Showing)
                {
                    timer += Time.deltaTime;
                    if (timer >= charsPerSecond)
                    {
                        currentPos++;
                        convtext.text = ConvSet.Instance().currconv.Substring(0, currentPos);
                        if(currentPos>= ConvSet.Instance().currconv.Length)
                        {
                            ShowOverProcess();
                        }
                    }
                }
                break;
            case PanelType.RequestStop:
                convtext.text = ConvSet.Instance().currconv;
                ShowOverProcess();
                break;
            default:
                break;
            
        }

    }
    private void ShowOverProcess()
    {
        currentPos = 0;
        ConvSet.Instance().paneltype = PanelType.Stop;
        ConvSet.Instance().UpdateCurrConv();
    }
}
