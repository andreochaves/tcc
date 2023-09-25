using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    bool isAtive;

    void Start()
    {
        isAtive = true;
    }

    void Update()
    {
        StartCoroutine(Proximo());
    }

    IEnumerator Proximo()
    {
        if (isAtive)
        {
            Destroy(gameObject, 2);
            yield return new WaitForSeconds(1.9f);
            isAtive = false;
        }
        
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
