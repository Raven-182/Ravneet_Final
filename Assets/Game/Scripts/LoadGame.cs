using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    public float loadTime = 15f;
    public TMP_Text loadText;
    void Start()
    {
        StartCoroutine(SceneAsyncLoad("MainScene"));
    }


    IEnumerator SceneAsyncLoad(string scene)
    {
        AsyncOperation sceneOp = SceneManager.LoadSceneAsync(scene);
        sceneOp.allowSceneActivation = false;
        while (!sceneOp.isDone)
        {
            float prog = Mathf.Clamp01(sceneOp.progress / 0.9f);
            loadText.text = loadText.text = $"Loading... {(int)(prog * 100)}%" ;
           
            if (!sceneOp.allowSceneActivation && sceneOp.progress >= 0.9f)
            {
                yield return new WaitForSeconds(loadTime);
                sceneOp.allowSceneActivation = true;

            }
            yield return null;
        }

    }
}
