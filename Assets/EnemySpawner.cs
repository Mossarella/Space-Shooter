using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField]int waveConfigType = 0;

    // Start is called before the first frame update
    void Start()
    {
        //start currentwave
        var currentWave = waveConfigs[waveConfigType];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
        var newEnemy= Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.getWayPoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<FollowWayPoint>().SetWaveConfig(waveConfig);
            //this line call setwaveconfig from follow way point
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
