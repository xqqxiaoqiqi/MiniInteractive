using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvPanel : MonoBehaviour
{
    private Button convbutton;
    private Text convtext;
    private Text nametext;
    public float charsPerSecond = 0.2f;
    private float timer;
    void Awake()
    {
        convbutton = GetComponent<Button>();
        convtext = GetComponentsInChildren<Text>()[0];
        nametext = GetComponentsInChildren<Text>()[1];
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
    public void PanelOnclick()
    {
        switch (ConvSet.Instance().paneltype)
        {
            case PanelType.Ready:
                if(LevelManager.nextground!=null)
                {
                    LevelManager.Instance().UpdateGround();
                    LevelManager.nextground = null;
                }
                if(LevelManager.nextbgm!=null)
                {
                    AudioSet.Instance().PlayBGM(LevelManager.nextbgm);
                    LevelManager.nextbgm = null;
                }
                ConvSet.Instance().paneltype = PanelType.Showing;
                break;
            case PanelType.Showing:
                ConvSet.Instance().paneltype = PanelType.RequestStop;
                break;
            case PanelType.ReadyToChoice:
                ChoiceSet.Instance().ShowChoicePanel();
                break;
            case PanelType.NeedHide:
                ConvSet.Instance(). StopProcess();
                ConvSet.Instance().paneltype = PanelType.Ready;
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
                ConvSet.Instance().UpdateExpress();
                nametext.text = ConvSet.Instance().currname;
                if (ConvSet.Instance().paneltype == PanelType.Showing)
                {
                    timer += Time.deltaTime;
                    if (timer >= charsPerSecond)
                    {
                        ConvSet.currentPos++;
                        convtext.text = ConvSet.Instance().currconv.Substring(0, ConvSet.currentPos);
                        if(ConvSet.currentPos >= ConvSet.Instance().currconv.Length)
                        {
                            ConvSet.Instance().ShowOverProcess();
                        }
                    }
                }
                break;
            case PanelType.RequestStop:
                convtext.text = ConvSet.Instance().currconv;
                ConvSet.Instance().ShowOverProcess();
                break;
            default:
                break;
            
        }

    }

}
