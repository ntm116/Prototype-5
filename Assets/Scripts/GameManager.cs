using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public Transform gameOverTransform;

    public List<GameObject> targets;

    private int score;

    public bool isGameActive;

    [SerializeField]
    private float spawnRate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InitProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void InitProperties()
    {
        score = 0;
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        gameOverTransform.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverTransform.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int ind = Random.Range(0, targets.Count);
            Instantiate(targets[ind]);
        }
    }
}
