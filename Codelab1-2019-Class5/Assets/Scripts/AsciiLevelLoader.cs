using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    private const string LEVEL0 = "/level0.txt";

    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + LEVEL0;

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath,"X");
        }

        string[] inputLines = File.ReadAllLines(filePath);
        
        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == 'x') 
                {
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                    newWall.transform.position = new Vector3(x-line.Length/2f,inputLines.Length/2f-y);
                }
                
                if (line[x] == 'P') 
                {
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
                    newWall.transform.position = new Vector3(x-line.Length/2f,inputLines.Length/2f-y);
                }
                
                if (line[x] == 'G') 
                {
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Gold")) as GameObject;
                    newWall.transform.position = new Vector3(x-line.Length/2f,inputLines.Length/2f-y);
                }
                
                if (line[x] == 'T') 
                {
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
                    newWall.transform.position = new Vector3(x-line.Length/2f,inputLines.Length/2f-y);
                }
            }      
        }           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
