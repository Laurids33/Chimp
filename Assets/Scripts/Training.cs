using UnityEngine;
using TMPro;

public class Training : MonoBehaviour
{
    public GameObject[] Zahl = new GameObject[10];
    int zahlMax;

    public TextMeshProUGUI infoAnzeige;

    void Start()
    {
        zahlMax = 2;
        ButtonsVerteilen();
    }

    void ButtonsVerteilen()
    {
        for (int i = 0; i <= zahlMax; i++)
        {
            bool positionDoppelt;
            Vector3 positionNeu;

            do
            {
                positionNeu = new Vector3(
                UnityEngine.Random.Range(1, 15) * 50, 
                UnityEngine.Random.Range(1, 8) * 50 - 10, 
                0);
                positionDoppelt = false;

                for (int k = 0; k < i; k++)
                {
                    if((Zahl[k].GetComponent<RectTransform>().position - positionNeu).magnitude < 25)
                    {
                        positionDoppelt = true;
                        break;
                    }
                }
            }
            while(positionDoppelt);

            Zahl[i].GetComponent<RectTransform>().position = positionNeu;
        }

        for (int i = zahlMax + 1; i <= 9; i++)
        {
            Zahl[i].SetActive(false);
        }

        Invoke(nameof(ZahlenLoeschen), zahlMax);
    }

    void ZahlenLoeschen()
    {
        for (int i = 0; i <= zahlMax; i++)
        {
            Zahl[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        infoAnzeige.text = "Nacheinander anklicken";
        Invoke(nameof(InfoEntfernen), 1);
    }

    void InfoEntfernen()
    {
        infoAnzeige.GetComponent<RectTransform>().transform.Translate(0, 500, 0);
    }

    void Update()
    {
        
    }
}
