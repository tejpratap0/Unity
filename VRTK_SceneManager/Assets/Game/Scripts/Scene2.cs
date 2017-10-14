using System.Collections;
using UnityEngine;

public class Scene2 : MonoBehaviour {

    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Specular"));
        renderer.material.color = Color.green;
    }

    IEnumerator Start()
    {
        Debug.Log("Scene2 is started.");

        yield return new WaitForSeconds(3);
        GameController.instance.SwitchToScene1(); 
    } 
}
