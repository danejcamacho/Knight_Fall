using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNext : MonoBehaviour
{
    int nextLevel;
    MainManager mainManager;
    private void Awake() {
        do{
            nextLevel = Random.Range(5,SceneManager.sceneCountInBuildSettings);
            
        } while (nextLevel == SceneManager.GetActiveScene().buildIndex);

        mainManager = FindObjectOfType<MainManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        mainManager.IncreaseScore();
        if(mainManager.GetScore() >= mainManager.GetLevelsToWin()){
            SceneManager.LoadScene("End");
        }else{
            SceneManager.LoadScene(nextLevel);
        }
        
    }
}
