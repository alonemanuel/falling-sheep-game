using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    float SHRINK_FACTOR = 0.97f;


    bool shouldShrink = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        Vector3 newSize = new Vector3(transform.localScale.x * SHRINK_FACTOR, transform.localScale.y * SHRINK_FACTOR, 0);
        transform.localScale = shouldShrink ? newSize : transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        shouldShrink = collision.gameObject.CompareTag("Grass") ? true : shouldShrink;
    }
}
