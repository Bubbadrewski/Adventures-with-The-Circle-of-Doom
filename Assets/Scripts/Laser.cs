using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    GameObject theCircleofDoom;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _projectileSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaserRange());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * _projectileSpeed * Time.deltaTime);
    }
    
    IEnumerator LaserRange()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        Object.Destroy(_laser);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            TheCircleofDoom theCircleofDoom = other.transform.GetComponent<TheCircleofDoom>();
            theCircleofDoom.LaserShot();
            Object.Destroy(_laser);
        }
    }
}

