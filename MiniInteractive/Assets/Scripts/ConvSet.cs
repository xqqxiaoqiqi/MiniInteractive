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
    private int currnum = 0;
    public void GetConvList(string line)
    {
        ConvName.Add(line.Split(':').First());
        Conversation.Add(line.Split(':').Last());
    }
    public void UpdateCurrConv()
    {
        if(currnum>=Conversation.Count)
        {
            if(ChoiceSet.choiceresult != null)
            {
                ConvSet.Instance().paneltype = PanelType.ReadyToChoice;
            }
            else
            {
                LevelManager.Instance().GetConversation(LevelManager.Instance().nextscene);
            }
        }
        else
        {
            currconv = Conversation[currnum];
            currnum++;
            ConvSet.Instance().paneltype = PanelType.Ready;
        }

    }
}
