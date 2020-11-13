using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
   [SerializeField] private int waitingTime = 3;
   int currentSceneIndex;

   public void Start()
   {
      currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      if (currentSceneIndex == 0)
      {
         StartCoroutine(LoadNextScreenAfterWait());
      }      
   }
   IEnumerator LoadNextScreenAfterWait()
   {
      yield return new WaitForSeconds(waitingTime);
      LoadNextScene();
   }

   private void LoadNextScene()
   {
      SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void LoadLoadingScreen()
   {
      SceneManager.LoadScene("Splash Scene");
   }
}

