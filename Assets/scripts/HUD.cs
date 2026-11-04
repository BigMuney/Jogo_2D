using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Crystals crystals;
    public int inv;
    public string Name;
    public Image image;
    public int currenttarget;
    void Start()
    {
        Name = "nothing";
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currenttarget = (inv - crystals.currentinv <0) ? 3-inv : inv-crystals.currentinv;
        if (currenttarget == 0)
        {
            image.color = Color.white;
        }
        if (currenttarget == 1)
        {
            image.color = Color.blue;
        }
        if (currenttarget == 2)
        {
            image.color = Color.yellow;
        }
        Debug.Log(currenttarget);
    }
}
