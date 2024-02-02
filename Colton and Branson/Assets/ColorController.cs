using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static ColorController instance;
    public SlimeColor slimeColor;
    public GameObject Player;
    private SpriteRenderer PlayerRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        PlayerRenderer = Player.GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        PlayerRenderer.color = slimeColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRenderer.color = Color.Lerp(PlayerRenderer.color,slimeColor.color,25 * Time.deltaTime);
    }
}
