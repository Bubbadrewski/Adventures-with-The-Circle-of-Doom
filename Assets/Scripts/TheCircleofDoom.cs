using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCircleofDoom : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    private float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Random Movement below, add to test files remove from stable

        /*
        float horizontalInput = Random.Range(-11f, 11f);
        float verticalInput = Random.Range(-5f, 5f);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f, 11f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);
        */
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
