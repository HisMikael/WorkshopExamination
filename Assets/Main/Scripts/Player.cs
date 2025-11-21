using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int itemsNeeded;
    public static Player Instance;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int health;
    [SerializeField] TextMeshProUGUI itemText;
    private int itemsPickup;
    private void Awake()
    {
        Instance = this;
    }

    public void Damage(int damage)
    {
        health -= damage;
        text.text = "Health: "+health.ToString();
        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PickUpItem()
    {
        itemsPickup++;
        itemText.text = "Items: "+itemsPickup.ToString();
        if (itemsPickup >= itemsNeeded)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
