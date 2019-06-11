using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyForTest : MonoBehaviour
{

public void Awake()
    {
        ConvSet.Instance().paneltype = PanelType.Ready;
    }
private void TestShow()
    {

    }
}
