using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //All three available states
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    //All variables for the wave class
    [System.Serializable]
    public class Wave
    {
        public string s_name;
        public Transform t_enemy;
        public int i_count;
        public float f_rate;
    }

    private SpawnState ss_state = SpawnState.COUNTING;

    //Reference to the player
    [SerializeField] private Player p_player;

    //List of waypoints for the enemy AI to go through
    [SerializeField] private List<Transform> t_wayPoints;

    //An array of available spawn points
    public Transform[] t_spawnPoints;

    //An array of waves
    public Wave[] w_waves;

    //Next wave int
    private int i_nextWave = 0;

    //Timer between the waves
    public float f_timeBetweenwaves = 5f;

    //Countdown before a wave starts
    public float f_waveCountdown = 3f;

    //Timer to start checking if enemies are still alive
    public float f_searchCountdown = 1f;

    void Start()
    {
        //Check if there are active spawnpoints
        if (t_spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points in scene");
        }

        f_waveCountdown = f_timeBetweenwaves;
    }

    void Update()
    {
        //While waiting checks if all enemies are dead
        if (ss_state == SpawnState.WAITING)
        {
            if (!enemyisalive())
            {
                wavecompleted();
            }
            else
            {
                return;
            }
        }

        //Spawns the next wave when the wave countdown hits zero
        if (f_waveCountdown <= 0)
        {
            if (ss_state != SpawnState.SPAWNING)
            {
                StartCoroutine(spawnwave(w_waves[i_nextWave]));
            }
        }
        else
        {
            f_waveCountdown -= Time.deltaTime;
        }
    }

    //Checks to see if there are any waves left
    void wavecompleted()
    {
        Debug.Log("Wave Completed!");

        ss_state = SpawnState.COUNTING;
        f_waveCountdown = f_timeBetweenwaves;

        if (i_nextWave + 1 > w_waves.Length - 1)
        {
            i_nextWave = 0;
            Debug.Log("All waves are completed!!!!");
        }
        else
        {
            i_nextWave++;
        }
    }

    //Checks to see if there is an enemy with the enemy tag left
    bool enemyisalive()
    {
        f_searchCountdown -= Time.deltaTime;

        if (f_searchCountdown <= 0f)
        {
            f_searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    //Spawns the actual wave
    IEnumerator spawnwave(Wave _wave)
    {
        ss_state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.i_count; i++)
        {
            spawnenemy(_wave.t_enemy);
            yield return new WaitForSeconds(1f / _wave.f_rate);
        }

        ss_state = SpawnState.WAITING;

        yield break;
    }

    //Spawns the enemies using the enemyAI scrip
    void spawnenemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy" + _enemy.name);

        if (t_spawnPoints.Length == 0)
        {
            Debug.Log("No spawn points active.");
        }

        Transform _sp = t_spawnPoints[Random.Range(0, t_spawnPoints.Length)];
        EnemyAI eai_Enemy = Instantiate(_enemy, transform.position, transform.rotation).GetComponent<EnemyAI>();
        eai_Enemy.t_waypoints = t_wayPoints;
        eai_Enemy.p_player = p_player;

    }
}
