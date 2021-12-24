using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCircleofDoom : MonoBehaviour
{
    [SerializeField]
    private float _speed = 12f;
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inputs to change targeted locaton
        float horizontalInput = 1;
        float verticalInput = 1;
        /*
        if(GameObject.Find("Player").transform.position.x < 0)
        {
            horizontalInput = -horizontalInput;
        }
        if(GameObject.Find("Player").transform.position.y < 0)
        {
            verticalInput = -horizontalInput;
        }
        Debug.Log(GameObject.Find("Player").transform.position.y);
        */
        
        Vector2 playerLoc = new Vector2 (GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
        Vector2 circleLoc = new Vector2(transform.position.x, transform.position.y);

        Vector2 targetLoc = new Vector2 (playerLoc.x - circleLoc.x, playerLoc.y - circleLoc.y);

        targetLoc = new Vector2(Mathf.Clamp(targetLoc.x, -1, 1), Mathf.Clamp(targetLoc.y, -1, 1));

        //Moves towards two inputs at rate of _speed times deltaTime
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(targetLoc * _speed * Time.deltaTime);

        //X position wrap around
        float Xborderpos = 12;
        float Xborderneg = -12;
        if (transform.position.x > Xborderpos)
        {
            transform.position = new Vector3(Xborderneg+1, transform.position.y, 0);
        }
        else if (transform.position.x < Xborderneg)
        {
            transform.position = new Vector3(Xborderpos-1, transform.position.y, 0);
        }

        //Y position wrap around
        float Yborderpos = 6;
        float Yborderneg = -6;
        if (transform.position.y > Yborderpos)
        {
            transform.position = new Vector3(transform.position.x, Yborderneg+1, 0);
        }
        else if (transform.position.y < Yborderneg)
        {
            transform.position = new Vector3(transform.position.x, Yborderpos-1, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();

            player.SetCircleofDoomCollision();

            transform.position = new Vector3(Random.Range(-11f, 11f), Random.Range(-5f, 5f), 0);

        }
    }
}
