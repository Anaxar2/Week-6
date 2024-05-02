using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
     gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void SetDifficulty(float Difficulty)
    {
        gm.StartGame();
        gm.spawnRate = Difficulty;
        Debug.Log(gameObject.name + "was clicked");
    }
}
