using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) SceneManager.LoadScene("Seasons");
    }
}