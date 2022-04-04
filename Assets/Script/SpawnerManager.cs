using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject tacler;
    public GameObject wall;
    public float Xpos;
    void Start()
    {
        GameObject newObstacle = Instantiate(wall);
        newObstacle.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            int random = Random.Range(0, 3);
            if(random <= 1)
            {
                GameObject newObstacle = Instantiate(wall);
                newObstacle.transform.position = transform.position + new Vector3(0, 0.5f, 0);
            }
            if (random > 1)
            {
                GameObject newObstacle = Instantiate(tacler);
                newObstacle.transform.position = transform.position + new Vector3(0, 0, 0);
            }
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
