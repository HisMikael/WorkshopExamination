using UnityEngine;
using UnityEngine.Serialization;

public class EnemyTree : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != Player.Instance.gameObject)
            return;
        Player.Instance.Damage(attackDamage);
        attackDamage = 0;
        Destroy(gameObject);
    }
}
