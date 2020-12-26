using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField]int waveConfigType = 0;
    public bool looping=false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //start currentwave
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = waveConfigType; i <waveConfigs.Count ; i++)
        {
            var currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
        
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
        //Debug.Log(waveConfigType);
    }
}
