using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    WaveConfig waveConfig;
    [HideInInspector]public List<Transform> wayPoints;
    

    private int wayPointIndex = 0;
    // Start is called before the first frame update
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        this.waveConfig = waveConfigToSet;
        //Debug.Log(waveConfigToSet);
    }
    
    void Start()
    {
        //SetWaveConfig(waveConfig);
        wayPoints = waveConfig.getWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        MoveAlong();
        
    }
    private void MoveAlong()
    {
        if(wayPointIndex<=wayPoints.Count-1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, waveConfig.getEnemyMoveSpeed() * Time.deltaTime);

            if(transform.position==wayPoints[wayPointIndex].transform.position)
            {
                wayPointIndex ++;
            }
            if(wayPointIndex==wayPoints.Count)
            {
                wayPointIndex = 0;
            }
        }
    }
}
