using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    public static PlayerController instance;
    public Vector3 initialScale;

    int INITIAL_LIFE_COUNT = 3;
    int MAX_POINTS = 5;
    int INITIAL_SPEED = 30;
    float SHRINK_FACTOR = 0.97f;

    public bool shouldShrink = false;
    public bool isDisabled = false;

    public float speed;
    public Text pointCountTxt;
    public Text lifeCountTxt;
    public Text statusTxt;


    public Rigidbody2D rb2d;
    private int numOfPoints;
    public int numOfLives;

	// Use this for initialization
	void Start () {
        instance = this;
        initialScale = transform.localScale;
        rb2d = GetComponent<Rigidbody2D>();
        numOfLives = INITIAL_LIFE_COUNT;
        numOfPoints = 0;
        speed = INITIAL_SPEED;
        setLifeCount();
        setPointsCount();
        statusTxt.text = "";


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (!isDisabled)  rb2d.AddForce(movement * speed);

        Vector3 newSize = new Vector3(transform.localScale.x * SHRINK_FACTOR, transform.localScale.y * SHRINK_FACTOR, 0);
        transform.localScale = shouldShrink ? newSize : transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            ++numOfPoints;
            setPointsCount();
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            --numOfLives;
            setLifeCount();
            
        }
        else if (other.gameObject.CompareTag("Grass"))
        {
            shouldShrink = true;
            isDisabled = true;
        }
    }

    void setPointsCount()
    {
        pointCountTxt.text = "Points: " + numOfPoints.ToString();
        if (numOfPoints>=MAX_POINTS)
        {
            statusTxt.text = "You win!";
        }
    }

    public void setLifeCount()
    {
        lifeCountTxt.text = "Lives left: " + numOfLives.ToString();
        if (numOfLives == 0)
        {
            gameObject.SetActive(false);
            statusTxt.text = "Sadly, you are now dead.";
        }
    }
}