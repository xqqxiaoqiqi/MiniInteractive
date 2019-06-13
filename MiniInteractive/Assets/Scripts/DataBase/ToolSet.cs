using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSet : UnitySingleton<ToolSet>
{
    private string toolbuttonpath = "GamePrefabs/ToolButtonPrefab/";
    private string toolpath = "GamePrefabs/ToolPrefab/";
    private string cardpath = "img/file/";
    private GameObject toolbuttonpanel;
    private GameObject tooldetailpanel;
    private GameObject cardbutton;
    private GameObject showing;
    private string cardname;
    public Dictionary<string, GameObject> toolbuttonlist = new Dictionary<string, GameObject>();
    public Dictionary<GameObject,string> toollist = new Dictionary<GameObject, string>();
    private void Awake()
    {
        toolbuttonpanel = GameObject.Find("ToolButtonPanel");
        tooldetailpanel = GameObject.Find("ToolDetailPanel");
        cardbutton = GameObject.Find("CardButton");
        cardbutton.GetComponentInChildren<Button>().onClick.AddListener(ShowCard);
        tooldetailpanel.GetComponent<Button>().onClick.AddListener(HideDetail);
    }
    public void AddTool(string name)
    {
        GameObject toolbutton = (GameObject)Instantiate(Resources.Load(toolbuttonpath+name+"Button", typeof(GameObject)));
        toolbutton.GetComponent<RectTransform>().SetParent(toolbuttonpanel.transform, false);
        toolbuttonlist.Add(name,toolbutton);
        toollist.Add(toolbutton, name);
    }
    public void RemoveTool(string name)
    {
        toolbuttonlist.Remove(name);
        toollist.Remove(toolbuttonlist[name]);
        Destroy(toolbuttonlist[name]);
    }
    public void ShowDetail(string name)
    { 
        showing = (GameObject)Instantiate(Resources.Load(toolpath + name.Replace("(Clone)",""), typeof(GameObject)));
        showing.GetComponent<RectTransform>().SetParent(tooldetailpanel.transform,false);
        LevelManager.ShowPanel(tooldetailpanel);
    }
    public void HideDetail()
    {
        Destroy(showing);
        LevelManager.HidePanel(tooldetailpanel);
    }
    public void AddCard(string name)
    {
        cardname = name;
        cardbutton.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(cardpath + name,typeof(Sprite));
        LevelManager.ShowPanel(cardbutton);
    }
    public void ShowCard()
    {
        showing = (GameObject)Instantiate(Resources.Load(toolpath + "Card", typeof(GameObject)));
        showing.GetComponentInChildren<Image>().sprite = (Sprite)Resources.Load(cardpath + cardname,typeof(Sprite));
        showing.GetComponent<RectTransform>().SetParent(tooldetailpanel.transform, false);
        LevelManager.ShowPanel(tooldetailpanel);
    }
    public void RemoveCard()
    {
        cardname = null;
        LevelManager.HidePanel(cardbutton);
    }
}
