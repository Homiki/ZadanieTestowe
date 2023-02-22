using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedAgent : MonoBehaviour
{
    //bool isPanelOpened;

    public GameObject agentPanel;

    Renderer render;

    CapsuleCollider cc;

    AgentController controller;

    //AgentSpawner spawner;

    PanelController panelControl;

    private Color color = Color.green;


    // Start is called before the first frame update
    void Start()
    {
        //spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<AgentSpawner>();
        panelControl = GetComponent<PanelController>();
        controller = GetComponent<AgentController>();
        render = gameObject.GetComponent<Renderer>();
        cc = gameObject.GetComponent<CapsuleCollider>();
        //panelControl.isPanelOpened = false;
        agentPanel = GameObject.FindGameObjectWithTag("Panel");
        
    }

    // Update is called once per frame
    void Update()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            HighlightAgent(false);
            panelControl.isPanelOpened = false;
            panelControl.enabled = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (cc.Raycast(ray, out hit, 150.0f))
            {
                HighlightAgent(true);

                panelControl.enabled = true;
                panelControl.isPanelOpened = true;
                //controller.GetText();
            }
        }

        //---------PROBABLY NEED UI CONTROLLER--------

        //if (panelControl.isPanelOpened == true)
        //{
        //    //agentPanel.transform.localScale = new Vector3(1, 1, 1);
        //    //Debug.Log("TRUE");
        //    //panelControl.enabled = true;
        //}
        //else if (panelControl.isPanelOpened == false)
        //{
        //    //agentPanel.transform.localScale = new Vector3(0, 0, 0);
        //    //Debug.Log("FALSE");
        //    //panelControl.enabled = false;
        //}

        //if (isPanelOpened == true)
        //{
        //    //agentPanel = GameObject.FindGameObjectWithTag("Panel");
        //    //agentPanel.SetActive(true);
        //    agentPanel.transform.localScale = new Vector3(0, 0, 0);
        //    Debug.Log("TRUE");
        //}
        //else if (isPanelOpened == false)
        //{
        //    //agentPanel.transform.localScale = new Vector3(1, 1, 1);
        //    Debug.Log("FALSE");
        //}
    }

    public void HighlightAgent(bool val)
    {
        if (val/*Input.GetMouseButtonDown(0)*/)
        {
            render.material.EnableKeyword("_EMISSION");
            render.material.SetColor("_EmissionColor", color);

            controller.GetText();

            //agentPanel.transform.localScale = new Vector3(1, 1, 1);

            Debug.Log("Clicked");
            //spawner.isPanelOpened = true;
        }
        else /*if (Input.GetMouseButtonUp(0))*/
        {
            render.material.DisableKeyword("_EMISSION");
            //spawner.isPanelOpened = false;
            agentPanel.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log("Unclicked");

        }

    }
}
