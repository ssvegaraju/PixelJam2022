using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public static LevelLoaderScript instance;
    bool loadingLevel = false;
    public float sceneTransitionTime = 1f;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene(){
        if(!loadingLevel){
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
        
    }

    public void LoadNextScene(){

        if(!loadingLevel){
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadScene(int sceneNumber){
        loadingLevel = true;
        animator.ResetTrigger("Scene Start");
        animator.SetTrigger("Scene End");
        yield return new WaitForSeconds(sceneTransitionTime);
        SceneManager.LoadScene(sceneNumber);
        loadingLevel = false;
        animator.ResetTrigger("Scene End");
        animator.SetTrigger("Scene Start");
    }
}
