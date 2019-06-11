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
    Hide
}
public class ConvSet : UnitySingleton<ConvSet>
{
    public static List<string> Conversation = new List<string>();
    public static List<string> ConvName = new List<string>();
    public PanelType paneltype;
    public string currconv;
    public string currname;
    private int currnum = 0;
    public void GetConvList(string line)
    {
        ConvName.Add(line.Split(':').First());
        Conversation.Add(line.Split(':').Last());
    }
    public void UpdateCurrConv()
    {
        //检测对话是否结束，如果结束则重置链表和计数器，未结束则加载新的对话文本
        if(currnum>=Conversation.Count)
        {
            Conversation.Clear();
            ConvName.Clear();
            currnum = 0;
            //如果有抉择事件的话，更改panel状态，否则认为剧情结束，直接加载新的场景剧本
            if(ChoiceSet.choiceresult.Count != 0)
            {
                ConvSet.Instance().paneltype = PanelType.ReadyToChoice;
            }
            else
            {
                if(LevelManager.Instance().needstop==false)
                {
                    LevelManager.Instance().GetConversation(LevelManager.Instance().nextscene);
                }
                else
                {
                    LevelManager.Instance().StopProcess();
                }
            }
        }
        else
        {
            currconv = Conversation[currnum];
            currname = ConvName[currnum];
            currnum++;
            ConvSet.Instance().paneltype = PanelType.Ready;
        }

    }
}
