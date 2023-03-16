using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;

    PlayerController Plc;
    
    public Transform leftTop;
    public Transform rightBottom;

    float dist;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Plc = Player.GetComponent<PlayerController>();

        leftTop = GameObject.Find("Left Top").GetComponent<Transform>();
        rightBottom = GameObject.Find("Right Bottom").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position);
        if(dist < 15 && dist > 3)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
                float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
                Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
                transform.position = newPos;
            }
        }
    }

    public void OnCollisionEnter(Collision pla)
    {
        if(pla.gameObject.name == "Player")
        {  
            Plc.canMove = false;
        }
    }
}
