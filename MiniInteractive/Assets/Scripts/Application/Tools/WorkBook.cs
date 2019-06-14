using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBook : MonoBehaviour
{
    private Button left;
    private Button right;
    public List<Sprite> pagelist = new List<Sprite>();
    private int pagenum = 0;
    void Awake()
    {
        left = GameObject.Find("Left").GetComponent<Button>();
        right = GameObject.Find("Right").GetComponent<Button>();
        left.onClick.AddListener(TurnLeft);
        right.onClick.AddListener(TurnRight);
        pagenum = 0;
        GetComponent<Image>().sprite = pagelist[0];
    }
    void TurnLeft()
    {
        AudioSet.Instance().PlayButton("click");
        if (pagelist[pagenum-1]!=null)
        {
            GetComponent<Image>().sprite = pagelist[pagenum-1];
            pagenum--;

        }
    }
    void TurnRight()
    {
        AudioSet.Instance().PlayButton("click");
        if (pagelist[pagenum + 1] != null)
        {
            GetComponent<Image>().sprite = pagelist[pagenum + 1];
            pagenum++;

        }
    }
}
