using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform player;
    public GameObject playerObj;

    [SerializeField] private float smoothfollow = 0.5f;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CameraMovement();
    }


    private void CameraMovement()
    {
        Vector3 DesiredPos = new Vector3();
        if (playerObj.transform.localScale.x > 0 && !(offset.x < 0))
        {
            DesiredPos = new Vector3(player.position.x - offset.x,player.position.y + offset.y, player.position.z + offset.z);
        }
        else// if(playerObj.transform.localScale.x > 0 && !(offset.x > 0))
        {
            DesiredPos = player.position + offset;   //new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        }

        Vector3 SmoothedPos = Vector3.Lerp(transform.position, DesiredPos, smoothfollow);
        transform.position = SmoothedPos;

        //transform.LookAt(player);
    }
        
}
