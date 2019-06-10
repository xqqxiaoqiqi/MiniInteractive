using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using LitJson;

public class LevelManager : UnitySingleton<LevelManager>
{
    private TextAsset ConvAsset;
    private static string ConvPackage = "DataBase/ConvData";
    private List<string> Conversation = new List<string>();
    private List<string> ConvName = new List<string>();
    private JsonData cardsJsonData;
    private string nextscene;
    private Dictionary<string, JsonData> Data = new Dictionary<string, JsonData>();
    void Awake()
    {
        ConvAsset = Resources.Load<TextAsset>(ConvPackage);
        cardsJsonData = JsonMapper.ToObject(ConvAsset.text);

    }
    private void Start()
    {
        InstalizeAllData();
        GetConversation("0_1");
    }
    private void InstalizeAllData()
    {
        for(int i=0;i<cardsJsonData.Count;i++)
        {
            Data.Add(cardsJsonData[i]["ID"].ToString(), cardsJsonData[i]);
        }
    }
    /// <summary>
    /// 根据
    /// </summary>
    /// <param name="nums"></param>
    public void GetConversation(string nums)
    {
        System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
        string[] lines = Data[nums]["Conversation"].ToString().Split(new char[] { '\r', '\n','\t',' ' }, option);
        for (int i=0; i<lines.Length;i++)
        {
            Debug.Log(lines[i]);
            ConvName.Add(lines[i].Split(':').First());
            Conversation.Add(lines[i].Split(':').Last());
        }
        if(Data[nums].ContainsKey("choice"))
        {
            Debug.Log("Setchoice");
            SetChoice(Data[nums]["choice"].ToString());
        }
    }
    private void SetChoice(string message)
    {
        System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
        string[] choices = message.Split(new char[] { '\r', '\n', '\t', ' ' }, option);
        for(int i=0;i<choices.Length;i++)
        {
            string[] details = choices[i].Split('=');
            ChoiceSet.choicestext.Add(details.First());
            ChoiceSet.choiceresult.Add(details.Last());
        }
    }
    
}
