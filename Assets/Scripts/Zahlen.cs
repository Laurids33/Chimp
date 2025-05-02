using UnityEngine;
using TMPro;
using System;

public class Zahlen : MonoBehaviour
{
    static int erwartet = 0;
    public Training training;

    public void Button_Click()
    {
        int geklickt = Convert.ToInt32(name.Substring(4, 1));

        if (geklickt == erwartet)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = geklickt + "";
            if (erwartet == training.zahlMax)
            {
                erwartet = 0;
                training.Vorwaerts();
            }
            else
            {
                erwartet++;
            }
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = "X";
            erwartet = 0;
            training.Zurueck();
        }
    }

}
