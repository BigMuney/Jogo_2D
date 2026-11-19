using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Crystals crystals;
    public int inv;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crystals.inventory[inv] == 0) // when the player has nothing it turns them white
        {
            image.color = Color.white;
        }
        if (crystals.inventory[inv] == 1) // when the player is currently holding the wing crystal it sets their color to blue
        {
            image.color = Color.blue;
        }
        if (crystals.inventory[inv] == 2) // when the player is currently holding the dash crystal their color is set to yellow
        {
            image.color = Color.yellow;
        }
    }
}
