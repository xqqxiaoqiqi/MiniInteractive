using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSet : UnitySingleton<AudioSet>
{
    //private string SEPath = "audio/SE";
    //private string BGMPath = "audio/BGM";
    public void PlaySE(string name)
    {
        Debug.Log("Play" + name);
    }
    public void PlayBGM(string name)
    {
        Debug.Log("Play" + name);
    }
}
