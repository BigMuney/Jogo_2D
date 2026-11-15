using UnityEngine;

public class crystalpickup : MonoBehaviour
{
    Player player = FindFirstObjectByType<Player>();
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            player = collision.GetComponent<Player>();
            if (Player.crystals.inventory[Player.crystals.currentinv] == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
