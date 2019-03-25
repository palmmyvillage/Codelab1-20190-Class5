using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HIGH_SCORE_FILE = "/myHighScore.txt"; //use this to set the name of hgihscore record file

    public List<string> hsNames;
    public List<int> hsScores;
    
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + HIGH_SCORE_FILE;

        if (!File.Exists(filePath)) //if the file does not exist
        {
            //create the file
            string output = "";

            for (int i = 0; i < 10; i++)
            {
                output += "Matt:" + (10-i) + '\n';
            }
            
            Debug.Log(output);
            File.WriteAllText(filePath,output);
        }
        
        //do this if wanna make it private
        //hsNames = new List<string>();
        //hsScores = new List<int>();
        
        //if file exist, add data to the game
        string[] inputLines = File.ReadAllLines(filePath);
        for (int i = 0; i < inputLines.Length; i++)
        {
            string line = inputLines[i]; //ex: "Matt:10"
            string[] splitLine = line.Split(':'); //ex: "Matt" | "10"
            string name = splitLine[0]; //ex: "Matt"
            int score = Int32.Parse(splitLine[1]); //ex: "10" > 10
            
            hsNames.Add(name);
            hsScores.Add(score);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
