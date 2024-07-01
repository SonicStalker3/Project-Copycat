using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float ladder_speed;
    [SerializeField] private GameObject PlayerHandler;
    [SerializeField] private Transform oldParent;
    public Transform UpperPoint;
    public Transform UnderPoint;

    public void SetParent(Transform player)
    {
        oldParent = player.transform.parent;
        PlayerHandler.transform.SetParent(player);
    }
    
    public void ResetParent(Transform player)
    {
        player.transform.SetParent(oldParent);
        PlayerHandler.transform.SetParent(player);
    }
    
    
}
