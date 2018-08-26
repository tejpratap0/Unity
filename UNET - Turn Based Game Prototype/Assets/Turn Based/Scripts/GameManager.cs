using UnityEngine; 
 
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [HideInInspector]
    public Player LocalPlayer;
    [HideInInspector]
    public Player OtherPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    } 
} 