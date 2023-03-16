using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int objNum;
    public List<GameObject>collectables = new List<GameObject>();
    
    public GameObject objCollect;

    public Transform leftTop;
    public Transform rightBottom;

    public int EneNum;
    public GameObject Enemy;
    public GameObject[] Enemies;

    
    public int Collected;
    public TMP_Text collectedText;


    public GameObject play;
    public PlayerController PlayerController;


    public TMP_Text countDown;
    
    
    public float timeLeft = 20f;

    // Start is called before the first frame update
    void Start()
    {
        countDown.text = "Time Left: " +timeLeft;
        play = GameObject.Find("Player");
        PlayerController = play.GetComponent<PlayerController>();

        EneNum = 20;
        GameObject[] Enemies = new GameObject[EneNum];

        collectedText.text = "Cubes Collected: " +Collected;

        for(int i = 0; i < EneNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newEn = Instantiate(Enemy, newPos, Quaternion.identity);
            Enemies[i] = newEn;
            Enemies[i].transform.name = ("Enemy" + i);
        }

        

        for(int i = 0; i < objNum; i++)
        {
            float newX = Random.Range(leftTop.position.x, rightBottom.position.x);
            float newZ = Random.Range(rightBottom.position.z, leftTop.position.z);
            Vector3 newPos = new Vector3(newX, transform.position.y, newZ);
            GameObject newObj = Instantiate(objCollect, newPos, Quaternion.identity);
            collectables.Add(newObj);
            newObj.transform.name = "Item " +collectables.Count;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(timeLeft <=0f)
        {
            timeLeft = 0f;
            PlayerController.canMove = false;
            countDown.text = "Times Up!";
        }
        else
        {
            timeLeft-=Time.deltaTime;

            int time = Mathf.RoundToInt(timeLeft);
            countDown.text = "Time Left: " +time;
            
            
        }

    }

    

    
}
