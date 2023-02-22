using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedAgent : MonoBehaviour
{
    public GameObject agentPanel;

    Renderer render;
    CapsuleCollider cc;
    AgentController controller;
    PanelController panelControl;

    private Color color = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        panelControl = GetComponent<PanelController>();
        controller = GetComponent<AgentController>();
        render = gameObject.GetComponent<Renderer>();
        cc = gameObject.GetComponent<CapsuleCollider>();
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
                
            }
        }
        if(panelControl.isPanelOpened == true)
        {
            controller.GetText();
        }
    }

    public void HighlightAgent(bool val)
    {
        if (val)
        {
            render.material.EnableKeyword("_EMISSION");
            render.material.SetColor("_EmissionColor", color);

            controller.GetText();

            Debug.Log("Clicked");
        }
        else
        {
            render.material.DisableKeyword("_EMISSION");
            agentPanel.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log("Unclicked");
        }
    }
}
