using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int score=0;

     void Update()
    {
      scoreText.GetComponent<Text>().text = "SCORE: " + score;
    }
}
