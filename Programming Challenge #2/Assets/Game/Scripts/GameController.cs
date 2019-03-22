using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public SceneReference GameScene;
    public MenuClassifier mainMenu;
    public MenuClassifier HUD;

    private Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetSceneByName(GameScene);
    }

    public void PlayGame()
    {
        if (_scene.isLoaded == false)
        {
            Debug.Log("Loading Game Scene: " + GameScene);
            SceneLoader.Instance.LoadLevel(GameScene, true);
        }

        MenuManager.Instance.showMenu(HUD);
        MenuManager.Instance.hideMenu(mainMenu);
    }
}
