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
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 randomSpawnPosition = new Vector3(Random.Range(-47, 48), 5.1f, Random.Range(-47, 48));
        Instantiate(agentObject, randomSpawnPosition, Quaternion.identity);

    }
}
