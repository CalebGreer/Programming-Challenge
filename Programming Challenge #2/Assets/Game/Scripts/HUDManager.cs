using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : Singleton<HUDManager>
{
    public Text coinCount;
    public Text timeElapsed;

    private float timer = 0.0f;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        coinCount.text = "Coins: " + score;
        timeElapsed.text = "Play Time: " + timer.ToString("F2");
    }

    public void IncreaseScore()
    {
        score++;
    }
}
