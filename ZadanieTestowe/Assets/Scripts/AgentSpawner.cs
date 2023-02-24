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

    //testy
    public int deadAgent;
    IEnumerator coroutine;
    //bool CR_running;

    public float spawningTime;

    //----List of names---
    List<string> nameList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        AgentName();

        //Spawning starting agents
        for (int i = 1; i <= startingAgent; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
            var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
            clone.name = nameList[Random.Range(0, nameList.Count)];
            spawnedAgents++;
        }


        //spawnedAgents -= startingAgent;
        //maxAgent -= spawnedAgents;
        remainingAgents = maxAgent;

        //Coroutine for spawning delayed agent


        StartCoroutine(Waiter());
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingAgents = maxAgent - spawnedAgents;
        //StartCoroutine(Waiter());

        //if (remainingAgents > 0)
        //{
        //    Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
        //    var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
        //    clone.name = nameList[Random.Range(0, nameList.Count)];
        //    spawnedAgents++;
        //}
        remainingAgents += deadAgent;

        //if (coroutine != null)
        //{
        //    StopCoroutine(coroutine);
        //}
        //coroutine = Waiter();
        //StartCoroutine(coroutine);
        //maxAgent = spawnedAgents - deadAgent;

    }

    IEnumerator Waiter()
    {
        //CR_running = true;
        remainingAgents = maxAgent - spawnedAgents + deadAgent;
        //remainingAgents += deadAgent;
        if (remainingAgents > 0)
        {
            
            //for (int i = 1; i <= remainingAgents; i++)
            //{
                yield return new WaitForSeconds(spawningTime);
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
                var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
                clone.name = nameList[Random.Range(0, nameList.Count)];
                spawnedAgents++;
            //}
            //yield break;
            //coroutine = null;
        }
        //if (remainingAgents > 0)
        //{
        //    yield return new WaitForSeconds(spawningTime);
        //    Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
        //    var clone = Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
        //    clone.name = nameList[Random.Range(0, nameList.Count)];
        //    spawnedAgents++;
        //    //yield break;
        //}
        else if (remainingAgents <= 0 /*&& spawnedAgents - deadAgent==30*/)
        {
            //_ = coroutine != null;
            yield return new WaitForSeconds(spawningTime);
        }

        //CR_running = false;
        //coroutine = null;
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
