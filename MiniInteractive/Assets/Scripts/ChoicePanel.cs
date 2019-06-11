using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePanel : MonoBehaviour
{
    public static Dictionary<Button,string> buttonlist = new Dictionary<Button,string>();
    public void UpDateChoicePanel()
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
