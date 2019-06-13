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
    private JsonData cardsJsonData;
    public string nextscene;
    public bool needstop = false;
    private Dictionary<string, JsonData> Data = new Dictionary<string, JsonData>();
    void Awake()
    {
        ConvAsset = Resources.Load<TextAsset>(ConvPackage);
        cardsJsonData = JsonMapper.ToObject(ConvAsset.text);

    }
    private void Start()
    {
        InstalizeAllData();
        GetGameFlow("0_1");
    }
    private void InstalizeAllData()
    {
        for(int i=0;i<cardsJsonData.Count;i++)
        {
            Data.Add(cardsJsonData[i]["ID"].ToString(), cardsJsonData[i]);
        }
    }
    /// <summary>
    /// 根据id获取对应的json代码块，初始化场景和对话文本
    /// </summary>
    /// <param name="nums"></param>
    public void GetGameFlow(string nums)
    {
        GameData.BeZero();
        System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
        string[] lines = Data[nums]["Conversation"].ToString().Split(new char[] { '\r', '\n','\t',' ' }, option);
        for (int i=0; i<lines.Length;i++)
        {
            Debug.Log(lines[i]);
            GameData.ProcessConversation(lines[i],i);
        }
        ConvSet.Instance().UpdateCurrConv();
        if(Data[nums].ContainsKey("Choice"))
        {
            Debug.Log("Setchoice");
            SetChoice(Data[nums]["Choice"].ToString());
        }
        if(Data[nums].ContainsKey("Next"))
        {
            nextscene = Data[nums]["Next"].ToString();
        }
        if(Data[nums].ContainsKey("Stop"))
        {
            needstop = true;
        }
    }
    /// <summary>
    /// 设置场景选项文本
    /// </summary>
    /// <param name="message"></param>
    private void SetChoice(string message)
    {
        System.StringSplitOptions option = System.StringSplitOptions.RemoveEmptyEntries;
        string[] choices = message.Split(new char[] { '\r', '\n', '\t', ' ' }, option);
        for(int i=0;i<choices.Length;i++)
        {
            string[] details = choices[i].Split('=');
            GameData.choicestext.Add(details.First());
            GameData.choiceresult.Add(details.Last());
        }
    }

    public static void ShowPanel( GameObject thispanel)
    {
        thispanel.GetComponent<CanvasGroup>().alpha = 1;
        thispanel.GetComponent<CanvasGroup>().interactable = true;
        thispanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public static void HidePanel(GameObject thispanel)
    {
        thispanel.GetComponent<CanvasGroup>().alpha = 0;
        thispanel.GetComponent<CanvasGroup>().interactable = false;
        thispanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
