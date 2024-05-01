using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header ("Target Speed")]
    Rigidbody rb;
    private float minSpeed = 6;
    private float maxSpeed = 8;

    [Header ("Target Rotation")]
    private float maxTorque = 5;

    [Header ("Target Spawn Range")]
    private float xRange = 4;
    private float ySpawnpos = -0.5f;

    [Header("Target Boundries")]
    public float upperBound = 14;
    public float lowerBound = -5;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>(); // gives access to rigid body component.
     rb.AddForce(RandomForce(), ForceMode.Impulse); // 
     rb.AddTorque(0, 0, RandomTorque(), ForceMode.Impulse); //
     transform.position = RandomSpawnPos(); // 
     gm = GameObject.Find("Game Manager").GetComponent<GameManager>(); // gives access to the Game Manager Game Object.
    }
    Vector3 RandomForce() //
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed); // sets random speed using these variables.
    }
    float RandomTorque() //
    {
        return Random.Range( -maxTorque, maxTorque); // sets random rotation on game objects.
    }
    Vector3 RandomSpawnPos() // 
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnpos); // spawns objects in a random place using these variables range.
    }
    // Update is called once per frame
    void Update()
    {

    if(transform.position.y > upperBound || transform.position.y < lowerBound) // if object goes beyond this variable value.
    {
     Destroy(gameObject); // destroys gaem object this script is a a component of.
    }

    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
