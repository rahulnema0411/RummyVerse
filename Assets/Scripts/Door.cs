using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LevelManager.instance.IsKeyCollected())
        {
            Debug.Log("Collect Key to Advance to the next Level");
            return;
        }

        if(SceneManager.GetActiveScene().buildIndex < 2)
        {
            Debug.Log("Congrats you completed the level");
            AudioManager.instance.PlayLevelCompleteSound();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Congrats you completed all the levels");
            AudioManager.instance.PlayGameWinSound();
            LevelManager.instance.ShowWinScreen();
        }
    }
}
