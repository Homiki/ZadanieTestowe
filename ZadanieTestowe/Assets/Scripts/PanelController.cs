using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public bool isPanelOpened;

    public GameObject agentPanel;

    // Start is called before the first frame update
    void Start()
    {
        agentPanel = GameObject.FindGameObjectWithTag("Panel");
        isPanelOpened = false;
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPanelOpened == true)
        {
            
            agentPanel.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("TRUE");
        }
        else
        {
            agentPanel.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log("FALSE");
        }
    }
}
