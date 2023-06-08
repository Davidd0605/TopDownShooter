using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] list;
    private int spawnIndex;

    private int wave;
    private int EnemyCount;

    public PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        playerControl= GameObject.Find("Player").GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = FindObjectsOfType<ZoombieControl>().Length;
        if (!playerControl.GameOver)
        {
            if (EnemyCount == 0)
            {
                
                Debug.Log("Wave: " +  wave);
                wave++;
                for (int i = 0; i < wave; i++)
                    Spawn();
            }
            

        }
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Spawn ()
    {
        spawnIndex = Random.Range(0, list.Length);
        Instantiate(list[spawnIndex], new Vector3(Random.Range(-10, 10), Random.Range(-6, 6)), list[spawnIndex].transform.rotation); 
    }
}
