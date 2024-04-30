using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;

    [Header("Health")]
    private int Health;
    public TextMeshProUGUI healthText;

    [Header("Kills")]
    private int Kills;
    public TextMeshProUGUI killsText;

    [Header("Sanity")]
    private int Sanity;
    public TextMeshProUGUI sanityText;

    [Header ("Audio")]
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();

        {
            StartCoroutine(SpawnTarget());
            
            Health = 5;
            SubtractHealth(0);

            Kills = 0;
            UpdateKills(0);

            Sanity = 10;
            IncreaseSanity(0);
        }
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void IncreaseHealth(int healthToAdd)
    {
        Health += healthToAdd;
        healthText.text = "Health:" + Health;
    }
    public void SubtractHealth(int healthToSubtract)
    {
        Health -= healthToSubtract;
        healthText.text = "Health:" + Health;
    }
    public void UpdateKills(int killsToAdd)
    {
        Kills += killsToAdd;
        killsText.text = "Kills:" + Kills;
    }
    public void IncreaseSanity(int sanityToAdd)
    {
        Sanity += sanityToAdd;
        sanityText.text = "Sanity:" + Sanity;
    }
    public void subtractSanity(int sanityTooSubtract)
    {
        Sanity -= sanityTooSubtract;
        sanityText.text = "Sanity:" + Sanity;
    }
    // Update is called once per frame
    void Update()
    {
      
    }

}
