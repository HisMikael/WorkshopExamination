using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelAfterTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI showTimeText;
    [SerializeField] private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        showTimeText.text = "Time Left: "+MathF.Floor(timer+1).ToString();
        if (timer <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
