using System.Collections; 
using UnityEngine;

public class Scene1 : MonoBehaviour {


    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Specular"));
        renderer.material.color = Color.blue;
    }

    IEnumerator Start()
    {
        Debug.Log("Scene1 is started.");

        yield return new WaitForSeconds(3);
        GameController.instance.SwitchToScene2();  
    }

}
