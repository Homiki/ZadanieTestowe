using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentController : MonoBehaviour
{
    public int health;
    int maxHealth = 3;
    int damage;

    public Text HealthText;
    public Text NameText;


    public Material damaged;
    public Material normal;
    public Renderer agent;

    public GameObject spawner;
    AgentSpawner agentspawn;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("AgentSpawner");
        agentspawn = spawner.GetComponent<AgentSpawner>();
        health = maxHealth;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            agentspawn.deadAgent++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Agent"))
        {
            health -= damage;

            StartCoroutine(HurtAgent());
        }
    }

    IEnumerator HurtAgent()
    {
        agent.material = damaged;
        yield return new WaitForSeconds(0.5f);
        agent.material = normal;
    }

    public void GetText()
    {
        HealthText = GameObject.FindGameObjectWithTag("AgentCurrentHP").GetComponent<Text>();
        NameText = GameObject.FindGameObjectWithTag("AgentName").GetComponent<Text>();

        HealthText.text = health.ToString();
        NameText.text = gameObject.name;
    }
}
