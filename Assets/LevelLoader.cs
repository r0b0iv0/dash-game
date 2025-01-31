using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{   
    [SerializeField] public Animator animator;
    [SerializeField] private float transitionTime = 1;
    
    public void StartTransition()
    {
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Transition(int sceneIndex) {
        animator.SetTrigger("PlayTransition");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }   
}
