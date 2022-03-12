using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstacles;
    private float pos;
    private int index;
    private bool startGame;
    private PlayerMovement playerState;
    private int count = 0;
    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        StartCoroutine(spawnObstacle());
        music.Play();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        startGame = GameObject.Find("Player").GetComponent<PlayerMovement>().gameOver;
    }
    IEnumerator spawnObstacle()
    {
        while (!(startGame))
        {
           index = Random.Range(0, 4);
           yield return new WaitForSeconds(3);
           Instantiate(obstacles[index], obstacles[index].transform.position, obstacles[index].transform.rotation); 
        }
    }
 
}
