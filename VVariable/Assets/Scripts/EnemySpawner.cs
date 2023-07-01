using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class EnemySpawner : MonoBehaviour
{
    #region EnemySpawner Variables

    [SerializeField] public GameObject[] availableEnemies;
    [SerializeField] public GameObject realDoor;
    [SerializeField] public GameObject playerPrefab;
    public static Vector3 playerLocation;

    public List<GameObject> enemiesList;
    public Transform[] enemiesLocations;
    public int numberOfEnemies;
    public static int enemiesCounter;

    #endregion

    #region  EnemySpawner Start & Update
   
    async void Start()
    {
        await RealStart();
        
    }
    public async Task RealStart()
    {
        if (PlayerHP.looped == true)
        {
            enemiesCounter = 0;

        }
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var randomEnemy = GenerateRandomEnemy(i);
            enemiesList.Add(randomEnemy);
            randomEnemy.transform.position = enemiesLocations[i].position;
            enemiesCounter++;
            
            
            

        }
        
    }

    void Update()
    {
        playerLocation = playerPrefab.transform.position;
        
        if (enemiesCounter == 0)
        {
            //Debug.Log("no more enemies");
            Destroy(realDoor);
            enemiesList.Clear();
        }
    }

    #endregion

    #region Enemy Generator
    public GameObject GenerateRandomEnemy(int wheretoInstantiate)
    {
        int randomIndex = Random.Range(0,availableEnemies.Length /*numberOfEnemies*/);
        var toInstantiate = Instantiate(availableEnemies[randomIndex],
            enemiesLocations[wheretoInstantiate]);
        return toInstantiate;
    }

    public void CheckIfPaused()
    {
        if (PauseMenu.Pause != false)
        {
            DOTween.PauseAll();
        }
    }
    #endregion

}