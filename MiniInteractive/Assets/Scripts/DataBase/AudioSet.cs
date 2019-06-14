using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSet : UnitySingleton<AudioSet>
{
    private string sepath = "audio/SE/";
    private string bgmpath = "audio/BGM/";
    private AudioSource sesource;
    private AudioSource bgmsource;
    private AudioSource buttonsource;
    private void Awake()
    {
        sesource = GameObject.Find("SE").GetComponent<AudioSource>();
        bgmsource = GameObject.Find("BGM").GetComponent<AudioSource>();
        buttonsource = GameObject.Find("ButtonSource").GetComponent<AudioSource>();
    }
    public void PlaySE(string name)
    {
        name = name.Replace("Play-", "");
        sesource.clip = (AudioClip)Resources.Load(sepath + name, typeof(AudioClip));
        sesource.Play();
        Debug.Log("Play" + name);
    }
    public void PlayBGM(string name)
    {
        bgmsource.clip = (AudioClip)Resources.Load(bgmpath + name, typeof(AudioClip));
        bgmsource.loop = true;
        bgmsource.Play();
        Debug.Log("Play" + name);
    }
    public void PlayButton(string name)
    {
        name = name.Replace("Play-", "");
        buttonsource.clip = (AudioClip)Resources.Load(sepath + name, typeof(AudioClip));
        buttonsource.Play();
        Debug.Log("Play" + name);
    }

}
