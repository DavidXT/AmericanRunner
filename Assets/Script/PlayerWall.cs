using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    public float speed;
    public List<GameObject> Children;
     // Start is called before the first frame update
    void Start()
    {
        speed = speed + ((int)GameManager.instance.Timer / 30);
        int destroyNumber = Random.Range(0, Children.Count-2);
        Destroy(Children[destroyNumber + 2]);
        Destroy(Children[destroyNumber + 1]);
        Destroy(Children[destroyNumber]);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.back * speed * Time.deltaTime;
        if (transform.position.z < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
