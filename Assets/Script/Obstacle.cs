using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if(playerController != null)
            {
                if (playerController.canLose)
                {
                    if (GameManager.instance != null)
                    {
                        GameManager.instance.GameOver();
                    }
                }
            }
        }
    }
}
