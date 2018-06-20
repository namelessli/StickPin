using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Transform startPos;
    public Transform creatPos;

    public GameObject musicPrefabs;
    private GameObject musicInstance = null;

    public Text scoreText;
    private int score;

    public GameObject pinPrefab;
    private Pin currentPin;
    private bool isGameOver = false;

    public Camera mainCamera;
    private float speed = 3f;


    void Start()
    {  
        CreatPin();
        musicInstance = GameObject.FindGameObjectWithTag("Music");
        if(musicInstance == null)
        {
            musicInstance = (GameObject)Instantiate(musicPrefabs);
        }
    }

    void Update()
    {
        if (isGameOver) return;
        if(Input.GetMouseButtonDown(0))
        {
            score++;
            scoreText.text = score.ToString();
            currentPin.StartFly();
            CreatPin();
        }
        if(Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }

    void CreatPin()
    {
        currentPin = Instantiate(pinPrefab, creatPos.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            GameObject.Find("Circle").GetComponent<CircleRotation>().enabled = false;
            StartCoroutine("GameOverAnimation");
        }
        isGameOver = true;
    }

    IEnumerator GameOverAnimation()
    {
        while(true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, speed * Time.deltaTime);
            if(Mathf.Abs(mainCamera.orthographicSize - 4)<0.01f)
            {
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
