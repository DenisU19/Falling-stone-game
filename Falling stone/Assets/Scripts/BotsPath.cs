using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotsPath : MonoBehaviour
{
    public Transform raycastStartPoint;
    NavMeshAgent botsNawMesh;
    public GameObject[] safeZone;
    public Transform currentSafeZone;
    private float minSafeZoneDistance;
    public Transform[] wayPoint;
    public Transform currentWayPoint;
    private float minWayPointDistance;
    public LayerMask raycastMask;
    Animator botAnim;
    void Start()
    {
        botAnim = GetComponent<Animator>();
        botsNawMesh = GetComponent<NavMeshAgent>();
        safeZone = GameObject.FindGameObjectsWithTag("Safe zone");
        minWayPointDistance = Mathf.Infinity;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(raycastStartPoint.position, -safeZone[0].transform.right);
        Debug.DrawRay(raycastStartPoint.position, -safeZone[0].transform.right * 40f);
        if (StartTimer.isGameStart)
        {
            if (Physics.SphereCast(raycastStartPoint.position, 1.5f, -safeZone[0].transform.right, out hit, 40f, raycastMask))
            {
                //Debug.Log("FindSafeZone");
                FindSafeZone();
            }
            else
            {
                //Debug.Log("GoToFinish");
                GoToFinish();
            }
            if (!botsNawMesh.hasPath)
            {
                botAnim.SetBool("BotStop", true);
            }
            else
            {
                botAnim.SetBool("BotStop", false);
            }
        }
    }
    private void FindSafeZone()
    {
        minSafeZoneDistance = Mathf.Infinity;
        for (int i = 0; i < safeZone.Length; i++)
        {
            if (Vector3.Distance(transform.position, safeZone[i].transform.position) < minSafeZoneDistance) 
            {
                minSafeZoneDistance = Vector3.Distance(transform.position, safeZone[i].transform.position);
                currentSafeZone = safeZone[i].transform;
            }
        }
        botsNawMesh.SetDestination(currentSafeZone.position);
    }
    private void GoToFinish()
    {
        for (int i = 0; i < wayPoint.Length; i++)
        {
            if (Vector3.Distance(transform.position, wayPoint[i].position) < minWayPointDistance)
            {
                minWayPointDistance = Vector3.Distance(transform.position, wayPoint[i].position);
                currentWayPoint = wayPoint[i];
            }
        }
        botsNawMesh.SetDestination(currentWayPoint.position);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(raycastStartPoint.position, 1.5f);
    }
}
