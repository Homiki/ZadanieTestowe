using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickedAgent : MonoBehaviour
{
    bool isPanelOpened;

    GameObject agentPanel;

    Renderer render;

    CapsuleCollider cc;

    AgentController controller;

    private Color color = Color.green;


    // Start is called before the first frame update
    void Start()
    {
        agentPanel = GameObject.FindGameObjectWithTag("Panel");
        render = gameObject.GetComponent<Renderer>();
        cc = gameObject.GetComponent<CapsuleCollider>();
        controller = GetComponent<AgentController>();
        isPanelOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPanelOpened == true)
        {
            agentPanel.SetActive(true);
        }
        else
        {
            agentPanel.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            HighlightAgent(false);
            isPanelOpened = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (cc.Raycast(ray, out hit, 200.0f))
            {
                HighlightAgent(true);
                controller.GetText();
                isPanelOpened = true;
            }
        }
    }

    public void HighlightAgent(bool val)
    {
        if (val/*Input.GetMouseButtonDown(0)*/)
        {
            render.material.EnableKeyword("_EMISSION");
            render.material.SetColor("_EmissionColor", color);
        }else /*if (Input.GetMouseButtonUp(0))*/
        {
            render.material.DisableKeyword("_EMISSION");
        }

    }
}
