using UnityEngine;
using UnityEngine.Networking; 
 
public class Player : NetworkBehaviour
{
    private string message;

    [SyncVar(hook = "OnTurnChange")]
    public bool Turn;
           
    private void Start()
    {
        if (isLocalPlayer )
        {
            GameManager.Instance.LocalPlayer = this; 
        }
        else
        {
            GameManager.Instance.OtherPlayer = this;
        }
    }
         
    public void OnTurnChange(bool turn)
    {
        Debug.Log(" [ OnTurnChange Called ] ");
        Turn = turn;

        if (isLocalPlayer)
        {
            if (Turn)
            {
                message = "YOUR TURN, Click Space!";
                OnTurnStart();
                    
            }
            else
            { 
                message = "OPPOPNENT TURN";
            }
        }
           
    }

    // Called when the local player object has been set up.
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();  
        // If player is not server then send server coin toss event.
        if (!isServer && isLocalPlayer)
        {
            FindObjectOfType<NetworkManagerHUD>().enabled = false;
            // Toss dicides who wins   
            CmdCoinToss(Random.value < 0.5); 
        }
    }   
           
    [Command]
    public void CmdCoinToss(bool turn)
    { 
        GameManager.Instance.LocalPlayer.Turn = !turn;
        GameManager.Instance.OtherPlayer.Turn = turn;
        FindObjectOfType<NetworkManagerHUD>().enabled = false;
    }

    [Command]
    void CmdOnPlayerTurnComplete()
    {
        GameManager.Instance.LocalPlayer.Turn = !GameManager.Instance.LocalPlayer.Turn;
        GameManager.Instance.OtherPlayer.Turn = !GameManager.Instance.OtherPlayer.Turn;
    } 

    public void OnTurnStart()
    {
        transform.GetComponent<TurnManager>().Started();
    }

    public void OnTurnEnd()
    {
        CmdOnPlayerTurnComplete();
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        { 
            GUI.Label(new Rect(Screen.width/3, Screen.height/10, Screen.width / 3, Screen.height / 10), message);
        }
    }
} 