using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public double spawnTime = 1;
    public float heightOff = 0.15f;
    private float timer = 0;

    void SpawnPipe()
    {
        float lowP = transform.position.y - heightOff, highP = transform.position.y + heightOff;
        Vector3 randomPos = new Vector3(transform.position.x, Random.Range(lowP, highP), 0);
        Instantiate(pipe, randomPos, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        // SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = Random.Range(-0.8f, 0.2f);
        }

    }
}
