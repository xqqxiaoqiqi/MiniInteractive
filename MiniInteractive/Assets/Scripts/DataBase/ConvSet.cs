using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PanelType
{
    Ready,
    Showing,
    RequestStop,
    Stop,
    ReadyToChoice,
    NeedHide,
    Hiding
}
public class ConvSet : UnitySingleton<ConvSet>
{

    public PanelType paneltype;
    public string currconv;
    public string currname;
    public string nexttool;
    public string nextaudio;
    public string nextexpression;
    private int nextnum = 0;
    public GameObject ConvPanel;
    public static int currentPos = 0;
    private bool allowupdate = false;
    private void Awake()
    {
        ConvPanel = GameObject.Find("ConversationPanel");
    }

    public void UpdateCurrConv()
    {
        //检测对话是否结束，如果结束则重置链表和计数器，未结束则加载新的对话文本
        if (nextnum >= GameData.conversation.Count)
        {
            GameData.conversation.Clear();
            GameData.speaker.Clear();
            nextnum = 0;
            //如果有抉择事件的话，更改panel状态，否则认为剧情结束，直接加载新的场景剧本
            if (GameData.choiceresult.Count != 0)
            {
                ConvSet.Instance().paneltype = PanelType.ReadyToChoice;
            }
            else
            {
                if (LevelManager.Instance().needstop == true)
                {
                    paneltype = PanelType.NeedHide;
                }
                else
                {
                    LevelManager.Instance().GetGameFlow(LevelManager.Instance().nextscene);
                }

            }
        }
        else
        {
            currconv = GameData.conversation[nextnum];
            currname = PorcessName(GameData.speaker[nextnum]);
            if(GameData.audiolist.ContainsKey(nextnum))
            {
                nextaudio = GameData.audiolist[nextnum];
            }
            else
            {
                nextaudio = null;
            }
            if(GameData.toollist.ContainsKey(nextnum))
            {
                nexttool = GameData.toollist[nextnum];
            }
            else
            {
                nexttool = null;
            }
            nextnum++;
            ConvSet.Instance().paneltype = PanelType.Ready;
            allowupdate = true;
        }

    }
    public void ShowOverProcess()
    {
        currentPos = 0;
        paneltype = PanelType.Stop;
        UpdateCurrConv();
    }
    public void StopProcess()
    {
        Debug.Log("Do StopPrpcess");
        LevelManager.HidePanel(ConvPanel);
        CountinueSet.Instance().ShowCountinuePanel();
        //显示continue按钮
    }
    public void CountinueProcess()
    {
        LevelManager.ShowPanel(ConvPanel);
        CountinueSet.Instance().HideCountinuePanel();
        LevelManager.Instance().GetGameFlow(LevelManager.Instance().nextscene);
    }
    private string PorcessName(string name)
    {
        string[] s = name.Split('@');
        if(s.Length!=1)
        {
            nextexpression = s.First().Replace("N_","")+"_"+s.Last();
        }
        else
        {
            nextexpression = null;
        }
        if(s.First().Contains("N_"))
        {
            return "???";
        }
        else
        {
            return s.First();
        }
    }
    public void UpdateExpress()
    {
        if(allowupdate)
        {
            allowupdate = false;
            if (nextaudio != null)
            {
                AudioSet.Instance().PlaySE(nextaudio);
            }
            if (nextexpression != null)
            {
                ImageSet.Instance().UpdateBustPanel(nextexpression);
            }
            if (nexttool != null)
            {
                string[] t = nexttool.Split('-');
                switch(t.First())
                {
                    case "Add":
                        if (t.Last().Contains("Card_"))
                        {
                            ToolSet.Instance().AddCard(t.Last());
                        }
                        else
                        {
                            ToolSet.Instance().AddTool(t.Last());
                        }
                        break;
                    case "Remove":
                        if (t.Last().Contains("Card_"))
                        {
                            ToolSet.Instance().RemoveCard();
                        }
                        else
                        {
                            ToolSet.Instance().RemoveTool(t.Last());
                        }
                        break;
                    default:
                        break;
                }
            }

        }

    }
}
