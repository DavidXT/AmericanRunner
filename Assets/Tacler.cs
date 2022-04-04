using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacler : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed += ((int)GameManager.instance.Timer / 30);
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
