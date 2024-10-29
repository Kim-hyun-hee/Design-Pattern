using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableOnLoad : MonoBehaviour
{
    [SerializeField]
    private List<string> activeWithinScenes;

    [Tooltip("지정되지 않은 경우 현재 GameObject로 기본 설정")]
    [SerializeField]
    private GameObject objectToDisable;
    [SerializeField]
    private bool debug;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneManager_SceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_SceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneManager_SceneLoaded;
        SceneManager.sceneUnloaded += SceneManager_SceneUnloaded;
    }

    private void Awake()
    {
        if (objectToDisable == null)
            objectToDisable = gameObject;
    }

    private void SceneManager_SceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        if (!activeWithinScenes.Contains(loadedScene.name))
        {
            DisableGameObject(loadedScene);
        }
    }

    private void SceneManager_SceneUnloaded(Scene unloadedScene)
    {
        if (activeWithinScenes.Contains(SceneManager.GetActiveScene().name))
        {
            EnableGameObject(unloadedScene);
        }
    }

    private void EnableGameObject(Scene scene)
    {
        objectToDisable.SetActive(true);

        if (debug)
        {
            Debug.Log("[DisableOnLoad] re-enabled GameObject: " + objectToDisable.name + "; unloaded scene: " + scene.name);
        }
    }

    private void DisableGameObject(Scene scene)
    {
        objectToDisable.SetActive(false);

        if (debug)
        {
            Debug.Log("[DisableOnLoad]  Disabled GameObject: " + objectToDisable.name + "; loaded scene: " + scene.name);
        }
    }
}
