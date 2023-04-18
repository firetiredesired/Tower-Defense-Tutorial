using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;
    
    public Transform spawnPoint;

	public float timeBetweenWaves = 240f;
	private float countdown = 2f;

	public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex;
	private int currentWave;

    public GameObject enemy01;
    public GameObject enemy02;
    public GameObject enemy03;
    public GameObject enemy04;
    public GameObject enemy05;



    void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (currentWave == 10f)
		{
			gameManager.WinLevel();
			this.enabled = false;

		}

		if (countdown <= 0f)
		{
			SpawnWave();
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	void SpawnWave()
	{
		PlayerStats.Rounds++;

        //Wave wave = waves[waveIndex];
        Debug.Log("kaa2s");
        //EnemiesAlive = wave;

       
        StartCoroutine(SpawnEnemy(waves[currentWave].enemies[0], waves[currentWave].enemies[1], waves[currentWave].enemies[2], waves[currentWave].enemies[3], waves[currentWave].enemies[4]));
        currentWave++;
	}

    IEnumerator SpawnEnemy(float _enemy01, float _enemy02, float _enemy03, float _enemy04, float _enemy05)
	{
		for (int i = 0; i < _enemy01; i++)
		{
			Instantiate(enemy01, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(30f / 40);
        }
		for (int i = 0; i < _enemy02; i++)
		{
			Instantiate(enemy02, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(30f / 40);
        }
		for (int i = 0; i < _enemy03; i++)
		{
			Instantiate(enemy03, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(30f / 40);
        }
        for (int i = 0; i < _enemy04; i++)
        {
            Instantiate(enemy04, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(30f / 40);
        }
        for (int i = 0; i < _enemy05; i++)
        {
            Instantiate(enemy05, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(30f / 40);
        }
			
    }

}
