using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{

    private float playerSpeed;
    private float turnSpeed;
    public const float acceleration = 0.08f;
    //private float addedSpeed;
    public GameObject myPrefab;
    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;
    public GameObject ship;
    public GameObject asteroidHolder;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject endMessage;
    public GameObject levelCompMessage;
    private int livesLeft = 3;
    private GameObject[] hearts = new GameObject[3];
    bool gameOver = false;
    public bool invincible = false;
    public float invincibleTimer = 0f;
    public bool lvlComplete = false;
    public int bigNum = 2;
    public int medNum = 3;
    public int smallNum = 4;




    private void Start()
    {
        hearts[0] = heartOne;
        hearts[1] = heartTwo;
        hearts[2] = heartThree;


        endMessage.SetActive(false);
        levelCompMessage.SetActive(false);
        

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            turnSpeed = -400.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            turnSpeed = 400.0f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerSpeed = acceleration;

            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.playerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerSpeed = -acceleration;

            this.GetComponent<Rigidbody>().AddForce(this.transform.up * this.playerSpeed);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            turnSpeed = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            turnSpeed = 0.0f;
        }





        if (turnSpeed != 0.0f)
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * turnSpeed, Space.World);
        }




        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GameObject newBullet = Instantiate(myPrefab, this.transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(this.transform.up * 100f);
            newBullet.transform.up = this.transform.up * 100f;
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            //GameObject newAsteroidHolder = Instantiate(asteroidHolder, this.transform.position, Quaternion.identity);
            
           
            this.transform.position = new Vector3(0f, .7f, 1f);


            //Destroy(GameObject.Find("AstroidHolder"));

            livesLeft = 3;
            bigNum = 2;
            medNum = 3;
            smallNum = 4;
            for (int i = 0; i < 3; i++)
            {
                hearts[i].transform.position = hearts[i].transform.position - new Vector3(0f, 50f, 0f);
            }
            foreach (Transform child in asteroidHolder.transform)
            {
                Destroy(child.gameObject);
            }

            newAsteroids();

            gameOver = false;

            GameObject.Find("HiScore").GetComponent<HighScoreScript>().score = Mathf.Max(GameObject.Find("Score").GetComponent<scoringScript>().score,
                GameObject.Find("HiScore").GetComponent<HighScoreScript>().score);

            GameObject.Find("Score").GetComponent<scoringScript>().score = 0;

            endMessage.SetActive(false);






        }

        if (asteroidHolder.transform.childCount == 0 && !lvlComplete)
        {
            smallNum++;
            medNum++;
            bigNum++;
            lvlComplete = true;
            levelCompMessage.SetActive(true);
        }

        if (lvlComplete && Input.GetKeyDown(KeyCode.N))
        {
            newAsteroids();
            levelCompMessage.SetActive(false);
            this.transform.position = new Vector3(0f, .7f, 1f);
            lvlComplete = false;
        }

            void newAsteroids()
        {
            for (int i = 0; i < bigNum; i++)
            {
                Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                GameObject newAsteroid3 = Instantiate(asteroid3, this.transform.position, Quaternion.identity);
                newAsteroid3.transform.position = new Vector3(Random.Range(-8f, 8f), .7f, 5f);
                newAsteroid3.GetComponent<Rigidbody>().AddForce(forceDir);
                newAsteroid3.transform.SetParent(asteroidHolder.GetComponent<Transform>());
            }
            for (int i = 0; i < medNum; i++)
            {
                Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                GameObject newAsteroid2 = Instantiate(asteroid2, this.transform.position, Quaternion.identity);
                newAsteroid2.transform.position = new Vector3(Random.Range(-8f, 8f), .7f, 5f);
                newAsteroid2.GetComponent<Rigidbody>().AddForce(forceDir);
                newAsteroid2.transform.SetParent(asteroidHolder.GetComponent<Transform>());
            }
            for (int i = 0; i < smallNum; i++)
            {
                Vector3 forceDir = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                GameObject newAsteroid1 = Instantiate(asteroid1, this.transform.position, Quaternion.identity);
                newAsteroid1.transform.position = new Vector3(Random.Range(-8f, 8f), .7f, 5f);
                newAsteroid1.GetComponent<Rigidbody>().AddForce(forceDir);
                newAsteroid1.transform.SetParent(asteroidHolder.GetComponent<Transform>());
            }
        }

        if (invincible)
        {
            if (invincibleTimer > .2)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            if (invincibleTimer > .5)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            if (invincibleTimer > .8)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            if (invincibleTimer > 1.1)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            if (invincibleTimer > 1.4)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
            if (invincibleTimer > 1.7)
            {
                this.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
            invincibleTimer += Time.deltaTime;
            if (invincibleTimer >= 2f)
            {
                invincible = false;
                invincibleTimer = 0f;
            }
        }






    }
    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "leftEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(-18, 0, 0);
        }
        if (collision.gameObject.name == "rightEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(18, 0, 0);
        }
        if (collision.gameObject.name == "topEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(0, 0, 11);
        }
        if (collision.gameObject.name == "bottomEdge")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            transform.position = transform.position + new Vector3(0, 0, -11);
        }

        if ((collision.gameObject.tag == "Asteroid1" ||
            collision.gameObject.tag == "Asteroid2" ||
            collision.gameObject.tag == "Asteroid3") && !invincible)
        {

            //If the GameObject's name matches the one you suggest, output this message in the console
            
            if (livesLeft > 0)
            {
                livesLeft--;
                hearts[livesLeft].transform.position = hearts[livesLeft].transform.position + new Vector3(0f, 50f, 0f);
                if (livesLeft > 0)
                {
                    transform.position = new Vector3(0f, .7f, 1f);
                }
                else
                {
                    transform.position = new Vector3(90f, 90f, 90f);
                    gameOver = true;
                    endMessage.SetActive(true);
                }
            }
            invincible = true;

        }

    }


    }