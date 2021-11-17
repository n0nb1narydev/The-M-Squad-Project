using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Type in the name of the Scene you would like to load in the Inspector
    public string battle_scene = "battle scene";

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject player;

    void Update()
    {
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(battle_scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(battle_scene));
        player.AddComponent<Player>();
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

    public void Launch()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

}
