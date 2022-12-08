using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Scene))]

public class SceneManagementBehaviour : MonoBehaviour
{
    public string sceneName; 
    
    public void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
