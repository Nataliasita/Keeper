using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{
    PrincipalMenu,
    Game,
    Level1,
    Level2,
    Level3,
    FightLevel1,
    FightLevel2,
    FightLevel3,
    FightBoss,
    Controsl,
    Credits,
    Win,
    GameOver
}
public class GameManager : MonoBehaviour
{
    // Inicializo el singleton en el primer script 
    public static int lostScene;
    [SerializeField] GameObject menuPausa;
    public static GameManager sharedInstance;
    public bool isPlaying;
    // Declaración del estado del juego
    public GameState currentGameState = GameState.PrincipalMenu;

    public SoundManager soundManager;
    public void Awake()
    {
        // que despierte y enfatizo con el siguiente fragmento
        // Singleton
        if (sharedInstance == null)
        {
            sharedInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start() {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }
    // Función encargado de iniciar la scena menú principal
    public void PrincipalMenu()
    {   
        SetGameState(GameState.PrincipalMenu);
    }
    // Función encargado de iniciar la scena Game
    public void Game()
    {
        SetGameState(GameState.Game);
    }

    public void Level1()
    {
        SetGameState(GameState.Level1);
    }
    public void Level2()
    {
        SetGameState(GameState.Level2);
    }
    public void Level3()
    {
        SetGameState(GameState.Level3);
    }
    public void FightLevel1()
    {
        SetGameState(GameState.FightLevel1);
    }
    public void FightLevel2()
    {
        SetGameState(GameState.FightLevel2);
    }
    public void FightLevel3()
    {
        SetGameState(GameState.FightLevel3);
    }
    public void FightBoss()
    {
        SetGameState(GameState.FightBoss);
    }
    // Función encargado de iniciar la scena créditos
    public void Controls()
    {
        SetGameState(GameState.Controsl);
    }
    // Función encargado de iniciar la scena controls
    public void Credits()
    {
        SetGameState(GameState.Credits);
    }
    public void Win()
    {
        SetGameState(GameState.Win);
    }
    // Función encargado de iniciar la scena de final de juego
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
    }

    public void SetGameState(GameState newGameState)
    {
        this.currentGameState = newGameState;

        if (newGameState == GameState.PrincipalMenu)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("Main Menu");
        }
        else if (newGameState == GameState.Game)
        {
            //TODO: colocar la logica del level game
            isPlaying = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene("SceneStart");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.Level1)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("Level1");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.Level2)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("Level2");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.Level3)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("Level3");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.FightLevel1)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("FightLevel1");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.FightLevel2)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("FightLevel2");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.FightLevel3)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("FightLevel3");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.FightBoss)
        {
            //TODO: colocar la logica del menu
            SceneManager.LoadScene("FightBoss");
            SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        }
        else if (newGameState == GameState.Controsl)
        {
            //TODO: colocar la logica de la scena Village
            SceneManager.LoadScene("Controls");
        }
        else if (newGameState == GameState.Credits)
        {
            //TODO: colocar la logica de la scena Credits
            SceneManager.LoadScene("Credits");
        }
        else if (newGameState == GameState.Win)
        {
            //TODO: colocar la logica de la scena Credits
            SceneManager.LoadScene("Win");
        }
        else if (newGameState == GameState.GameOver)
        {
            //TODO: colocar la logica de la scena Store
            SceneManager.LoadScene("GameOver");
        }
    }
    public void Pausa()
    {
        //TODO: colocar la logica de la pausa
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        isPlaying = false;
    }
    public void Reanudar()
    {
        //TODO: colocar la logica de la reanudar
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        isPlaying = true;
    }
    public void Abandonar()
    {
        //TODO: colocar la logica de abandonar
        Time.timeScale = 1f;
        PrincipalMenu();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
     public void Reiniciar()
    {
        SceneManager.LoadScene(GameManager.lostScene);
        SceneManager.LoadScene("UIElements", LoadSceneMode.Additive);
        
    }
}
