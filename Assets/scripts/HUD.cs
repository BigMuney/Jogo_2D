using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Crystals crystals;
    public int inv;
    public string Name;
    public Image image;
    void Start()
    {
        Name = "nothing";
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(crystals.inventory[inv] == 0)
        {
            image.color = Color.white;
        }
        if (crystals.inventory[inv] == 1)
        {
            image.color = Color.blue;
        }
        if (crystals.inventory[inv] == 2)
        {
            image.color = Color.yellow;
        }
    }
}
