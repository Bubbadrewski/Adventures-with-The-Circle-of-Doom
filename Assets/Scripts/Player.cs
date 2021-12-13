using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int weapons;
    private bool weaponsChecked;
    [SerializeField]
    private GameObject _THE_CIRCLE_OF_DOoM;
    [SerializeField]
    private GameObject _player;
    private int _circleColor;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private bool _hasCollided;
    [SerializeField]
    private float _lives = 4f;
    [SerializeField]
    private float _speedScalar = 4;
    // Start is called before the first frame update
    void Start()
    {
        weaponsChecked = true;

        _speedScalar = 4f;

        weapons = 0;

        Debug.LogFormat("You have");
        Debug.Log(_lives);
        Debug.Log("lives to start");

        _THE_CIRCLE_OF_DOoM.GetComponent<Renderer>().material.color = Color.red;
        _circleColor = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (!weaponsChecked)
        {
            if (weapons == 0)
            {
                Debug.Log("Fists");
             
            }
            else if (weapons == 1)
            {
                Debug.Log("No weapons for you");
                weapons = 0;
                
            }
            else
            {
                Debug.Log("You're not supposed to be here");
                weapons = 0;
            }
            weaponsChecked = true;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            weaponsChecked = false;
        }
        //pain follows
        /*
        if (_circleColor == 1)
        {
            _THE_CIRCLE_OF_DOoM.GetComponent<Renderer>().material.color = Color.white;
            _circleColor = 2;
        }
        else if (_circleColor == 2)
        {
            _THE_CIRCLE_OF_DOoM.GetComponent<Renderer>().material.color = Color.red;
            _circleColor = 1;
        }
        */
    }
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

  
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        if (_hasCollided == true)
        {
            _hasCollided = false;

            transform.position = new Vector3(Random.Range(-11f, 11f), Random.Range(-5f, 5f), 0);

            _lives = _lives - 1;
            Debug.Log(_lives);
            Debug.Log("lives left");
            if (_lives == 0)
            {
                Application.Quit();
                Debug.Log("attempted Quit");
            }

        }
        else
        {
            transform.Translate(direction * _speed * Time.deltaTime * _speedScalar);
        }
        // Up and down boundary or y boundary
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f, 11f), Mathf.Clamp(transform.position.y, -5f, 5f), 0);

       
        // The following causes the player to wrap around

        /* if (transform.position.x > 12)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -12)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, -5, 0);
        }
        else if (transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 5, 0);
        }
        */

       
    }
    public void SetCircleofDoomCollision()
    {
        _hasCollided = true;
    }
    public void ClearCircleofDoomCollision()
    {
        _hasCollided = false;
    }

}