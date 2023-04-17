using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    // Public lives
    public int lives;

    // Public highScore
    public int highScore;
    public List<LevelData> listLevel;
}
[Serializable]
public class LevelData
{
    // Public lives
    public int level;

    // Public highScore
    public int health;
}