using UnityEngine;
using TMPro;

public class Training : MonoBehaviour
{
    public GameObject[] Zahl = new GameObject[10];
    public int zahlMax;

    public TextMeshProUGUI infoAnzeige;

    readonly int zahlMaxGrenze = 9;
    public bool buttonsKlickbar = false;

    void Start()
    {
        zahlMax = 2;
        for (int i = 0; i <= 9; i++)
            Zahl[i].SetActive(false);
        Invoke(nameof(ButtonsVerteilen), 3);
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
                (Random.Range(1, 15) * 50 - 400) * 2,
                (Random.Range(1, 8) * 50 - 10 - 200) * 2,
                0) * 0.01f;

                positionDoppelt = false;

                for (int k = 0; k < i; k++)
                {
                    if ((Zahl[k].GetComponent<RectTransform>().position - positionNeu).magnitude < 100 * 0.01f)
                    {
                        positionDoppelt = true;
                        break;
                    }
                }
            }
            while (positionDoppelt);
            Zahl[i].GetComponent<RectTransform>().position = positionNeu;
        }

        for (int i = 0; i <= 9; i++)
        {
            if (i <= zahlMax)
            {
                Zahl[i].SetActive(true);
                Zahl[i].GetComponentInChildren<TextMeshProUGUI>().text = i + "";
            }
            else
            {
                Zahl[i].SetActive(false);
            }


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
        buttonsKlickbar = true;
    }

    void InfoEntfernen()
    {
        infoAnzeige.GetComponent<RectTransform>().transform.Translate(0, 500, 0);
    }

    public void Zurueck()
    {
        zahlMax--;
        infoAnzeige.GetComponent<RectTransform>().transform.Translate(0, -500, 0);
        infoAnzeige.text = "Fehler, zurück auf " + zahlMax;
        Invoke(nameof(Weiter), 2);
    }

    void Weiter()
    {
        infoAnzeige.text = "Position merken";
        ButtonsVerteilen();
    }

    public void Vorwaerts()
    {
        zahlMax++;
        buttonsKlickbar = false;
        infoAnzeige.GetComponent<RectTransform>().transform.Translate(0, -500, 0);

        if (zahlMax > zahlMaxGrenze)
        {
            infoAnzeige.text = "Mehr geht zurzeit nicht";
        }
        else
        {
            infoAnzeige.text = "Geschafft, vorwaerts auf " + zahlMax;
            Invoke(nameof(Weiter), 2);
        }

    }

    void Update()
    {

    }
}
