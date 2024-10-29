using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoad : MonoBehaviour
{
    [SerializeField]
    private List<string> activeWithinScenes;

    [Tooltip("지정되지 않은 경우 현재 GameObject로 기본 설정")]
    [SerializeField]
    private GameObject objectToDestroy;
    [SerializeField]
    private bool debug;

    private void Start()
    {
        if (!activeWithinScenes.Contains(SceneManager.GetActiveScene().name))
        {
            if (objectToDestroy == null)
                objectToDestroy = gameObject;

            Destroy(objectToDestroy);

            if (debug)
            {
                Debug.Log("Active scene: " + SceneManager.GetActiveScene().name);
                Debug.Log("Do not destroy in scene: " + string.Join(", ", activeWithinScenes));
                Debug.Log("Destroy on load: " + objectToDestroy);
            }
        }
    }
}
