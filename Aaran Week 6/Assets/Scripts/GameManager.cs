using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1f;

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
    private AudioSource _as;

    public Slider slider;

    public TextMeshProUGUI gameOverText;

    public bool isGameOver;

    bool isSanityLow;

    public Button restartButton;

    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.P))
         {
            pauseMenu.SetActive(true);
            Time.timeScale = 1;
        }
           

        {
            
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
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void StartGame()
    {
        StartCoroutine(SpawnTarget());
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
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
      
    }
    private void SanityLevel()
    {
     Instantiate(targets[0]);
     isSanityLow = true;
     _as.Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
     if(Sanity < 5 && isSanityLow == false) // if Sanity is less than 5 and (bool) anity 
        {
         SanityLevel();
        }
     if (Sanity >= 5)
        {
         _as.Stop();
          isSanityLow = false;
        }
        if (Health <= 0 || Sanity <= 0)
        {
            isGameOver = true;
        }
        if (isGameOver) GameOver();

        _as.volume = slider.value;
    }

}
