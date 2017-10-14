using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRTK;
 
public class GameController : MonoBehaviour {

    public static GameController instance; 
	
    void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<GameController>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); 
    }

    void Start()
    {
       
        SceneManager.LoadScene( Constants.SceneName.Scene1.ToString() );
    }
    public void SwitchToScene1()
    {
        //SceneManager.LoadScene( Constants.SceneName.Scene1.ToString() );
       StartCoroutine( switchScene(Constants.SceneName.Scene1.ToString()));
        
    }

    public void SwitchToScene2()
    {
        //SceneManager.LoadScene( Constants.SceneName.Scene2.ToString() ); 
        StartCoroutine(switchScene(Constants.SceneName.Scene2.ToString()));
    }

    IEnumerator switchScene(string sceneName)
    { 

        VRTK_HeadsetFade headsetFade = gameObject.GetComponentInChildren<VRTK_HeadsetFade>();

        headsetFade.Fade(Color.black, Constants.FadeSpeed);
        yield return new WaitForSeconds(Constants.FadeSpeed);

        Debug.Log("Loading Scene "+sceneName+"..."); 
        yield return SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("Loading Scene Done" + "...");
         
        headsetFade.Unfade(Constants.FadeSpeed);
        yield return new WaitForSeconds(Constants.FadeSpeed); 
    }
   
}
