using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour
{
    private static bool firstload = true;
    public static Dictionary<Button,string> buttonlist = new Dictionary<Button,string>();
    private void OnEnable()
    {
        if(firstload)
        {
            firstload = false;
        }
        else
        {
            Button[] b = this.GetComponentsInChildren<Button>();
            for (int i = 0; i < b.Length; i++)
            {
                Button button = b[i];
                if (!buttonlist.ContainsKey(button))
                {
                    buttonlist.Add(button, ChoiceSet.choiceresult[i]);
                }
                if (ChoiceSet.choicestext.Count - 1 >= i)
                {
                    button.GetComponentInChildren<Text>().text = ChoiceSet.choicestext[i];
                }
            }
        }

    }
}
