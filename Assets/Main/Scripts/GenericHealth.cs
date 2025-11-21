using UnityEngine;

public class GenericHealth : MonoBehaviour
{
    [SerializeField] int health;
    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
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
