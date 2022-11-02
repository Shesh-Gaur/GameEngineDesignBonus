using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public GameObject powerUp;
    public float spawnTimerMax = 5.0f;
    float spawnTimer = 1.0f;

    public Player player;
    float startingSpeed;
    public float powerUpTimerMax = 5.0f;
    float powerUpTimer = 0.0f;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if (instance && instance != this)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startingSpeed = player.speed;
    }
    public void PowerUpActivated()
    {
        powerUpTimer = powerUpTimerMax;
        Debug.Log("Power-Up Active!");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0.0f)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }

        if (powerUpTimer > 0.0f)
        {
            powerUpTimer -= Time.deltaTime;
            player.speed = startingSpeed * 1.5f;
        }
        else
        {
            player.speed = startingSpeed;
        }
    }
}
