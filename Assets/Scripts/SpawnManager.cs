using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _circleofdoomandfriends;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-12f, 12f), Random.Range(-6f, 6f), 0);
            Instantiate(_circleofdoomandfriends, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

}
