using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            --PlayerController.instance.numOfLives;
            PlayerController.instance.setLifeCount();

            other.gameObject.transform.position = new Vector3(0, 0, 0);
            PlayerController.instance.rb2d.velocity = Vector3.zero;
            PlayerController.instance.rb2d.angularVelocity = 0;
            other.transform.localScale = PlayerController.instance.initialScale;
            PlayerController.instance.isDisabled = false;
            PlayerController.instance.shouldShrink = false;
        }
        else if(other.gameObject.CompareTag("Bomb"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

