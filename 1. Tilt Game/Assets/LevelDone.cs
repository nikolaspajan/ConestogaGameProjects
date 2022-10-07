using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Destroy(GameObject.Find("Platform1"));
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Destroy(GameObject.Find("Platform2"));
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Destroy(GameObject.Find("Platform3"));
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }
}
