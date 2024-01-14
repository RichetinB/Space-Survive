using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Canvas gameOverCanvas = GameObject.FindObjectOfType<Canvas>();

        if (player != null)
        {
            player.SetActive(true);
            player.GetComponent<MoveSpaceship>().enabled = true;
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }
}