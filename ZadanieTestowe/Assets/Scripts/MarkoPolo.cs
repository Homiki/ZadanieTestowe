using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarkoPolo : MonoBehaviour
{
    int digit;

    public Text textPanel;
    public GameObject panelUI;

    bool isTextPanelOpened;
    


    // Start is called before the first frame update
    void Start()
    {
        digit = 1;
        isTextPanelOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTextPanelOpened == true)
        {
            panelUI.SetActive(true);
        }
        else if (isTextPanelOpened == false)
        {
            panelUI.SetActive(false);
        }
    }

    public void MarkoPoloDigit()
    {
        if (isTextPanelOpened == false)
        {
            isTextPanelOpened = true;

            for (int i = 1; i <= 100; i++)
            {
                if (digit % 3 == 0 && digit % 5 == 0)
                {
                    textPanel.text = textPanel.text += "MarkoPolo \n";
                }
                else if (digit % 5 == 0)
                {
                    textPanel.text = textPanel.text += "Polo \n";
                }
                else if (digit % 3 == 0)
                {
                    textPanel.text = textPanel.text += "Marko \n";
                }
                else
                {
                    textPanel.text = textPanel.text += digit.ToString() + "\n";
                }

                digit++;
            }
        }
        else if (isTextPanelOpened == true)
        {
            isTextPanelOpened = false;
            textPanel.text = "";
            digit = 1;
        }
    }
}
