using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class BestScore : MonoBehaviour
{
    public static BestScore Instance;

    public string PlayerName;
    public string bestPlayer;
    public int highScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlayer();
        LoadHighScore();
    }
    [System.Serializable]
    public class SaveData
    {
        public string bestPlayer;
        public int highScore;
    }
    public void SaveBestPlayer()
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }
    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData newData = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = newData.bestPlayer;
        }
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData newData = JsonUtility.FromJson<SaveData>(json);

            highScore = newData.highScore;
        }
    }
}
