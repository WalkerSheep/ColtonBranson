using System.Collections;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public GameObject Player;
    private Health PlayerHealth;
    public Color FlashColor;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        PlayerHealth = Player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealth.Dead)
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        Player.transform.position = new Vector3(0,0,0);
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ColorController.instance.slimeColor = ColorController.instance.DefaultColor;
        PlayerHealth.health = 3;
    }
}
