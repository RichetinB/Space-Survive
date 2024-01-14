using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Recharge la sc�ne actuelle (recommence le jeu)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // R�active le joueur et d�sactive le canvas Game Over
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Canvas gameOverCanvas = GameObject.FindObjectOfType<Canvas>();

        if (player != null)
        {
            player.SetActive(true);
            // Ajoute la ligne suivante pour activer le script MoveSpaceship
            player.GetComponent<MoveSpaceship>().enabled = true;
        }

        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }
}