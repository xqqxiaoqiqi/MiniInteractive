using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameData : UnitySingleton<GameData>
{
    public static List<string> conversation = new List<string>();
    public static List<string> speaker = new List<string>();
    public static List<string> choicestext = new List<string>();
    public static List<string> choiceresult = new List<string>();
    public static Dictionary<int,string> audiolist =new Dictionary<int, string>();
    public static Dictionary<int, string> toollist = new Dictionary<int, string>();
    private static string tail;
    private static string head;
    public static void BeZero()
    {
        conversation.Clear();
        speaker.Clear();
        choicestext.Clear();
        choiceresult.Clear();
        audiolist.Clear();
        toollist.Clear();
        Debug.Log("has cleaned");

    }
    public static void ProcessConversation(string line,int i)
    {
        GetDetail(conversation, line, ':');
        GetDetail(audiolist, head, '%',i);
        GetDetail(toollist, head, '*', i);
        speaker.Add(head);
        tail = null;
        head = null;
    }
    private static void GetDetail(List<string> list,string content,char symbol)
    {
       tail = content.Split(symbol).Last();
       head = content.Split(symbol).First();
        if (!head.Equals(tail))
        {
            list.Add(tail);
        }
    }
    private static void GetDetail(Dictionary<int,string>dict, string content,char symbol,int i)
    {
        tail = content.Split(symbol).Last();
        head = content.Split(symbol).First();
        if (!head.Equals(tail))
        {
            dict.Add(i,tail);
        }
    }
}
