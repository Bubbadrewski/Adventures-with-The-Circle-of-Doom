using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int weapons;
    private bool weaponsChecked;
    [SerializeField]
    private GameObject _THE_CIRCLE_OF_DOoM;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private bool _hasCollided;
    [SerializeField]
    private static float _lives = 4f;
    [SerializeField]
    private GameObject _laserPrefab;
    // Start is called before the first frame update
    void Start()
    {
        weaponsChecked = true;

        weapons = 0;

        //transform.position = new Vector3(Random.Range(-11f, 11f), Random.Range(-5f, 5f), 0);

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        //Used to define what weapon is being used
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            weaponsChecked = false;
        }
    }
    void CalculateMovement()
    {
         
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

  
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (_hasCollided == true)
        {
            _hasCollided = false;

            _lives = _lives - 1;
            Debug.Log(_lives);
            Debug.Log("lives left");
            if (_lives == 0)
            {
                Application.Quit();
                Debug.Log("attempted Quit");
            }
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            transform.Translate(direction * _speed * Time.deltaTime);
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