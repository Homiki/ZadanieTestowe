using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSpawner : MonoBehaviour
{
    //--------AgentPrefab---------
    public GameObject agentObject;

    //-----SpawningParameters-----
    public int startingAgent;
    public int maxAgent;
    public float spawningTime;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= startingAgent; i++)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
            Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0 ; i <= maxAgent; i++)
        //{
        //    StartCoroutine(Waiter());
        //    Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
        //    Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
        //}
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        //yield return new WaitForSeconds(spawningTime);

        for (int i = 0; i <= maxAgent; i++)
        {
            yield return new WaitForSeconds(spawningTime);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
            Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);
        }
    }
}
