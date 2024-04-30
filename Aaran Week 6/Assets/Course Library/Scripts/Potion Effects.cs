using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffects : MonoBehaviour
{
    private GameManager gm;
    private Targets targets;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
     gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
     targets = GetComponent<Targets>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnMouseDown()
    {
        gm.IncreaseSanity(1); // Increase Sanity by 2 when object is clicked on.
        Instantiate(explosion, transform.position, explosion.transform.rotation);
    }
}
