using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
     gm = gameObject.GetComponent<GameManager>();
     button =GetComponent<Button>();
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
