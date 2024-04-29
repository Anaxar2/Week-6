using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    [Header ("Target Speed")]
    Rigidbody rb;
    private float minSpeed = 6;
    private float maxSpeed = 10;

    [Header ("Target Rotation")]
    private float maxTorque = 5;

    [Header ("Target Spawn Range")]
    private float xRange = 4;
    private float ySpawnpos = -6;

    [Header("Target Boundries")]
    public float upperBound = 14;

    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
     rb.AddForce(RandomForce(), ForceMode.Impulse);
     rb.AddTorque(0, 0, RandomTorque(), ForceMode.Impulse);
     transform.position = RandomSpawnPos();
     gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(-minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range( -maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnpos);
    }
    // Update is called once per frame
    void Update()
    {

    if(transform.position.y > upperBound)
    {
     Destroy(gameObject);
    }

    }
    private void OnMouseDown()
    {
     Destroy(gameObject);
     gm.UpdateSanity(1);
    }
}
