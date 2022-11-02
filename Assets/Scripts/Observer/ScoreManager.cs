using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public abstract class Observer
{
    public abstract void OnPing();
}
public class ScoreManager : Observer
{
    public int score = 0;
    public TextMeshProUGUI myText;
    public GameObject myGameObject;
    public ScoreManager(GameObject gameObject, TextMeshProUGUI scoreText)
    {
        myGameObject = gameObject;
        myText = scoreText;
    }
    public override void OnPing()
    {
        score += 50;
        myText.text = "Score: " + score;
    }

}
