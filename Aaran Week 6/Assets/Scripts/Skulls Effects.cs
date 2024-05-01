using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullsEffects : MonoBehaviour
{
    private GameManager gm; // access game manager.
    private Targets targets;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
     gm = GameObject.Find("Game Manager").GetComponent<GameManager>(); // gives access to the Game Manager Game Object.
     targets = GetComponent<Targets>();
     gm.subtractSanity(1); // Increases Sanity by 1 when object is clicked on.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > targets.upperBound || transform.position.y < targets.lowerBound) // if object goes beyond this variable value.
        {
         gm.SubtractHealth(1); // subtracts 1 from Sanity Total.
         
        }
    }
    private void OnMouseDown()
    {
        gm.UpdateKills(1); // Increases Kills by 1 when object is clicked on.
        Instantiate(explosion, transform.position, explosion.transform.rotation); // Plays Particle effect.
    }
}
