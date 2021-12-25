using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCircleofDoom : MonoBehaviour
{
    [SerializeField]
    private float _speed = 12f;
    //this might be useless, further testing required
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Defines locations of player and self, then puts them into a vector2 called playerLoc and circleLoc repsectivley
        Vector2 playerLoc = new Vector2 (GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y);
        Vector2 circleLoc = new Vector2(transform.position.x, transform.position.y);

        //Finds the distance playerLoc is away from circleLoc, and defines that new vector2 as targetLoc
        Vector2 targetLoc = new Vector2 (playerLoc.x - circleLoc.x, playerLoc.y - circleLoc.y);

        //Moves towards targetLoc at rate of _speed times deltaTime
        targetLoc = new Vector2(Mathf.Clamp(targetLoc.x, -1, 1), Mathf.Clamp(targetLoc.y, -1, 1));
        transform.Translate(targetLoc * _speed * Time.deltaTime);

        //X,Y position wrap around useless for current build
        /*
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
        */
    }
    //below we trigger an action when the player collides with this object, action is defined in Player script
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag == "Player")
        {
            
            Player player = other.transform.GetComponent<Player>();
            player.SetCircleofDoomCollision();
     

        }
    }
}
