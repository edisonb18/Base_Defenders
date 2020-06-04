using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    public SpawnControl spawn;
    public int Score=0;
    public int Level=1;
    public float dificultyMultiplier = 1f;
    public int levelBoost = 100;
    public float dificultyBoost = 0.1f; //aumento por nivel
    public bool isLevelLineal;
    public bool isLevelSummation;
    public bool isDificultyLineal;
    public bool isDificultySummation;
    private int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        nextLevel = levelBoost;
    }
    public void AddPoints(int points)
    {
        Score += points;
        if (Score >= nextLevel)
            LevelUp();
    }
    private void SetNextLevel()
    {
        if (isDificultyLineal)
        {
            dificultyMultiplier = (int)(1 + dificultyBoost * Level);
        }
        else if (isDificultySummation)
        {
            dificultyMultiplier += dificultyBoost * Level;
        }
        else
        {
            dificultyMultiplier += dificultyBoost;
        }
        if (isLevelLineal)
        {
            nextLevel = levelBoost * Level;
        }
        else if (isLevelSummation)
        {
            nextLevel += levelBoost * Level;
        }
        else
        {
            nextLevel += levelBoost;
        }
    }
    private void LevelUp()
    {
        Level++;
        SetNextLevel();
        dificultyMultiplier += dificultyBoost;
        spawn.SetDificulty(dificultyMultiplier);
        //update spawn collections
    }
    // Update is called once per frame


}
