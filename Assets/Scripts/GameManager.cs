using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] wayPoint;
    public Transform player;
    bool startMove;
    public int playerPosPoint;
    public GameObject startButton;
    public static bool manAnimate;
    public float speed;
    public UIImage uIImage;

    // Start is called before the first frame update
    void Start()
    {
        playerPosPoint = 0;
        player.transform.position = wayPoint[playerPosPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMove && playerPosPoint != wayPoint.Length)
        {
            Move();
        } 
        else
        {
            playerPosPoint = 0;
        }
    }

    public void StartPlayerRun()
    {
        startMove = true;
        startButton.gameObject.SetActive(false);
    }

    void Move()
    {
        if (Vector3.Distance(player.transform.position, wayPoint[playerPosPoint].position) < 0.1f)
        {
            playerPosPoint++;
            uIImage.TriggerImageInstantiation(playerPosPoint);
        }
        else if (!manAnimate)
        {
            Vector3 rotation = Quaternion.LookRotation(wayPoint[playerPosPoint].position - player.transform.position).eulerAngles;
            rotation.x = 0f;
            rotation.z = 0f;
            player.transform.rotation = Quaternion.Euler(rotation);
            player.Translate(Vector3.forward * speed *  Time.deltaTime);
        }
    }
}
