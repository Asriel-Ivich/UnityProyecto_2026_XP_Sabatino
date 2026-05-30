using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject pausePanel; // Panel del menu de pausa
    public GameObject optionsPanel; // Panel de opciones

    [Header("Escenas")]
    public string mainMenuSceneName = "MainMenu";


    // Guarda si el juego esta pausado o no
    private bool isPaused = false;

    void Start()
    {

        //Asegura que corra normal
        Time.timeScale = 1f;

        //Al iniciar oculta los paneles
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        //bloquea y oculta el cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //regresamos el menu anterior
            if (optionsPanel.activeSelf)
            {
                CloseOptions();
            }
            //seguimos
            else if (isPaused)
            {
                ResumeGame();
            }
            //pausamos
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;

        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        isPaused = false;

        //reactivamos
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);

        Time.timeScale = 1f;

        //pculta
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OpenOptions()
    {
        //ocultamos
        pausePanel.SetActive(false);

        //mostramos el menu
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        //ocultamos
        optionsPanel.SetActive(false);

        //regresamos
        pausePanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        //retoma el tiempo antes de
        Time.timeScale = 1f;

        //semuestra el cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //menu principal
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        //cierra
        Application.Quit();
    }
}
