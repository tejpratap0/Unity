using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Sphere;
    private Transform cameraTransform;
	IEnumerator Start () { 
        while (GameObject.FindGameObjectWithTag("MainCamera") == null)
        {
            yield return null;
        }
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;

        Renderer renderer = Sphere.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Specular"));
        renderer.material.color  = Color.red;
    } 

	void FixedUpdate () {
        if (cameraTransform != null) {
            transform.position = new Vector3(cameraTransform.position.x, 0, cameraTransform.transform.position.z);
        }
	}
}
