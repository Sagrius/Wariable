using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EnemySpawner : MonoBehaviour
{
    #region Variables 

    public int numberOfEnemies;
    public static Vector3 playerLocation;
    public static int enemiesCounter;

    #endregion

    #region References

    public GameObject[] availableEnemies;
    public Transform[] enemiesLocations;
    public List<GameObject> enemiesList;
    public GameObject realDoor;
    public GameObject GuideArrow;
    public GameObject playerPrefab;
  
    #endregion

    #region Start & Update
   
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
            Destroy(realDoor);
            enemiesList.Clear();
            GuideArrow.SetActive(true);
        }
    }

    #endregion

    #region Enemy Generator
    public GameObject GenerateRandomEnemy(int wheretoInstantiate)
    {
        int randomIndex = Random.Range(0,availableEnemies.Length);
        var toInstantiate = Instantiate(availableEnemies[randomIndex],
            enemiesLocations[wheretoInstantiate]);
        return toInstantiate;
    }

    #endregion

}