using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy_prefab;
    public List<Transform> spawn_points = new List<Transform>();
    public PlayerMovement player;
    public List<GameObject> enemies; //lista instanciranih neprijatelja


    public void Awake() 
    {
        enemies = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // klasa mora da nasledjuje MonoBehaviour da bi mogla da startuje korutinu !!!
    public IEnumerator spawnCoroutine()  //korutine koristimo da se ne bi cela funkcija izvrsila u 1 frejmu 
        //korutina moze da zaustavi svoje izvrsavanje i nastavi kasnije sa mesta gde je stala
    {
        System.Random r = new System.Random();
        while (true)
        {
            int index = r.Next(0, spawn_points.Count);
            Vector3 spawn_position = spawn_points[index].position;

            GameObject enemy = Instantiate(enemy_prefab, spawn_position, Quaternion.identity);
            Enemy enemy_script = enemy.GetComponent<Enemy>();
            enemy_script.player = player.gameObject;
            enemies.Add(enemy);

            yield return new WaitForSecondsRealtime(2f);

        }
    }

}
