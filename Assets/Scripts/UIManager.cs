using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _livesText;
    private static float _livesCount = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _livesText.text = "Lives: " + _livesCount;
    }
    public void DamageTaken(float _lives)
    {
        _livesText.text = "Lives: " + _lives.ToString();
        _livesCount = _lives;
    }
    public void PointsUpdate()
    {
    
    }
}
