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

    [Header ("Kills")]
    private int Kills;
    public TextMeshProUGUI killsText;

    [Header ("Sanity")]
    private int Sanity;
    public TextMeshProUGUI sanityText;

    // Start is called before the first frame update
    void Start()
    {
     {
      StartCoroutine(SpawnTarget());
            Health = 3;
            healthText.text = "Health:" + Health;

            Kills = 0;
            killsText.text = "Kills:" + Kills;

            Sanity = 3;
            UpdateSanity(0);
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

   public void UpdateSanity(int sanityToAdd)
    {
        Sanity += sanityToAdd;
        sanityText.text = "Sanity:" + Sanity;
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
