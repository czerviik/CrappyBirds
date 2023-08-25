using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    //public void LoadNextScene()
    //{
    //    //dosadí index aktuální scéně
    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentSceneIndex + 1);
    //}

    public void LoadNextSceneTrans()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadStarScene()
    {
        StartCoroutine(LoadScene(0));
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }


    //transition enumerator
    IEnumerator LoadScene(int sceneIndex)
    {
        //play
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(sceneIndex);
    }

    
}
