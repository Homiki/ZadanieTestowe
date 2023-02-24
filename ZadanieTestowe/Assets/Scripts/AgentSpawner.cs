using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    //--------AgentPrefab---------
    public GameObject agentObject;

    //-----SpawningParameters-----
    public int spawnedAgents;
    public int remainingAgents;
    public int startingAgent;
    public int maxAgent;
    public int deadAgent;

    public float spawningTime;

    //----List of names---
    List<string> nameList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Adding names to list 
        AgentName();

        //Spawning starting agents
        for (int i = 1; i <= startingAgent; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
            var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
            clone.name = nameList[Random.Range(0, nameList.Count)];
            spawnedAgents++;
        }

        remainingAgents = maxAgent;

        //Coroutine for spawning delayed agent
        StartCoroutine(Waiter());      
    }

    // Update is called once per frame
    void Update()
    {
        remainingAgents = maxAgent - spawnedAgents;

        remainingAgents += deadAgent;
    }

    IEnumerator Waiter()
    {
        remainingAgents = maxAgent - spawnedAgents + deadAgent;

        if (remainingAgents > 0)
        {
                yield return new WaitForSeconds(spawningTime);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
                var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
                clone.name = nameList[Random.Range(0, nameList.Count)];
                spawnedAgents++;
        }
        else if (remainingAgents <= 0)
        {
            yield return new WaitForSeconds(spawningTime);
        }

        StartCoroutine(Waiter());
    }

    void AgentName()
    {
        nameList.Add("Krzysiek");
        nameList.Add("Adam");
        nameList.Add("Kornel");
        nameList.Add("Michal");
        nameList.Add("Ola");
        nameList.Add("Nikola");
        nameList.Add("Arek");
        nameList.Add("Patryk");
        nameList.Add("Dominik");
        nameList.Add("Franek");
        nameList.Add("Seweryn");
        nameList.Add("Dawid");
        nameList.Add("Mikolaj");
        nameList.Add("Klaudia");
        nameList.Add("Serhii");
        nameList.Add("Tomek");
        nameList.Add("Wojtek");
        nameList.Add("Zuzanna");
        nameList.Add("Roksana");
    }
}
