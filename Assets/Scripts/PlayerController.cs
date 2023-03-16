using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool canMove = true;

    public GameObject gameMan;
    public GameManager GameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        
        GameManager = gameMan.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        if(canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                newPos.z = newPos.z + speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                newPos.z = newPos.z - speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                newPos.x = newPos.x - speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                newPos.x = newPos.x + speed * Time.deltaTime;
            }
            
        }
        
        transform.position = newPos;
        
    }

    public void OnTriggerEnter(Collider Col)
    {
        
        if(Col.tag == "Collect")
        {  
            
           for(int i = 0; i < GameManager.collectables.Count; i++)
           {
             if(Col.gameObject == GameManager.collectables[i])
             {
                Destroy(GameManager.collectables[i]);
                GameManager.collectables.Remove(GameManager.collectables[i]);
                GameManager.Collected++;
                GameManager.collectedText.text = "Cubes Collected: " + GameManager.Collected;
             }
           }
        }
        
    }

        
    
}

