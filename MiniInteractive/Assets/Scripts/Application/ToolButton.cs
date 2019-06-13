using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolButton : MonoBehaviour
{
    //浮动显示文字
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        ToolSet.Instance().ShowDetail(gameObject.name.Replace("Button",""));
    }

}
