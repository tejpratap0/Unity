using UnityEngine;

public class TurnManager : MonoBehaviour {

    private bool active;


    public void Started()
    {
        active = true;
        transform.Find("Body").gameObject.SetActive(true);
    }

    public void Stopped()
    { 
        active = false;
        transform.Find("Body").gameObject.SetActive(false);

        GetComponent<Player>().OnTurnEnd();
    }
     
    private void Update()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(" [ SPACE PRESSED ] ");
                Stopped();
            }
        }

    }
}
