using UnityEngine;
using TMPro;
using System;

public class Zahlen : MonoBehaviour
{
    static int erwartet = 0;

    public void Button_Click()
    {
        int geklickt = Convert.ToInt32(name.Substring(4, 1));

        if (geklickt == erwartet)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = geklickt + "";
            erwartet++;
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "X";
        }
    }

}
