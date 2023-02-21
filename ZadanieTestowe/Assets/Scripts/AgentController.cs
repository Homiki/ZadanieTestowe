using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    int health;
    int maxHealth = 3;
    int damage;

    public Material damaged;
    public Material normal;
    public Renderer agent;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
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
}
