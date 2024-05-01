using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    /*[Header ("UI Elements")]
    public Slider slider;

    [Header("Audio")]
    private AudioSource AudioSource;*/

    private GameManager gm;
         
    // Start is called before the first frame update
    void Start()
    {
     //AudioSource.volume = slider.value;
     gm = GameObject.Find("Game Manger").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
  
}
