using UnityEngine;
using UnityEngine.SceneManagement; 

public class FinishLine : MonoBehaviour
{
    public string mainMenuSceneName = "MainScene"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
