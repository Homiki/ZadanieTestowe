using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    int health;
    int maxHealth = 3;
    int damage;
    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Agent"))
        {
            health -= damage;
        }
    }
}
