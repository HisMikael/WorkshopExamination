using UnityEngine;

public class Item : MonoBehaviour
{
    bool hasBeenPickedUp = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasBeenPickedUp)
            return;
        if (other.gameObject != Player.Instance.gameObject)
            return;
        hasBeenPickedUp = true;
        Player.Instance.PickUpItem();
        Destroy(gameObject);
    }
}
