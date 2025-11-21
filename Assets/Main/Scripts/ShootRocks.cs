using UnityEngine;

public class ShootRocks : MonoBehaviour
{
    bool hasDamaged = false;
    [SerializeField] private int AttackDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasDamaged)
            return;
        hasDamaged = true;
        Destroy(gameObject);
        GenericHealth health = collision.gameObject.GetComponent<GenericHealth>();
        if (health == null)
            return;
        health.Damage(AttackDamage);
    }
}
