using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{

    public static MainManager Instance;
    int score = 0;
    int levelsToWin = 8;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GameOver(){
        score = 0;
        SceneManager.LoadScene("YouLose");
    }

    public void PlayGame(){
        SceneManager.LoadScene("Start");
    }

    public void EndGame(){
        Application.Quit();
    }

    public void IncreaseScore(){
        score++;
        
    }

    public int GetScore(){
        return score;
    }

    public int GetLevelsToWin(){
        return levelsToWin;
    }
}
