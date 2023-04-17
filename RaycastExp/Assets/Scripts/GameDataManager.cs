using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{

    // Update the field once the persistent path exists.
    string saveFile = Application.streamingAssetsPath + "/gamedata.json";

    GameData gameData = new GameData();

    // Start is called before the first frame update
    void Start()
    {
        gameData = new GameData();
        gameData.lives = 10;
        gameData.highScore = 100;
        gameData.listLevel = new List<LevelData>();
        for (int i=0;i<5;i++)
        {
            LevelData temp = new LevelData();
            temp.level = i+1;
            temp.health = i + 5;
            gameData.listLevel.Add(temp);
        }
        writeFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void readFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Work with JSON
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
            gameData.lives++;
            gameData.highScore += 100;
            writeFile();
            Debug.LogError(gameData.highScore + " - " + gameData.lives);
        }
    }

    public void writeFile()
    {

        // Work with JSON
        // Serialize the object into JSON and save string.
        string jsonString = JsonUtility.ToJson(gameData);

        File.WriteAllText(saveFile, jsonString);
        Debug.Log(jsonString);
    }
}
