using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public Canvas canvas;
    public GameObject prefabBalloon;
    public Text textScore;
    public GameObject panelLose;
    public Text textLoseOrWin;

    public float speedMove; 
    public int score;
    
    float timer;
    float timeNextSpawn;

    void Start () {
        speedMove = 1;
        timer = 0;
        timeNextSpawn = 2.5f;
        Time.timeScale = 1;
    }
	
	void Update () {
        timer += Time.deltaTime;
        
        if(timer >= timeNextSpawn)
        {
            int posX = Random.Range(-Screen.width/2, Screen.width/2);
            int posY = -Screen.height;
            
            prefabBalloon.GetComponent<Image>().color = new Color(Random.Range(0f, 1000f) / 1000f, 
                                                                    Random.Range(0f, 1000f) / 1000f, 
                                                                    Random.Range(0f, 1000f) / 1000f); //ставим рандомный цвет

            GameObject obj = Instantiate(prefabBalloon.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
            obj.transform.SetParent(canvas.transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(posX, posY, 0);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            obj.transform.SetSiblingIndex(0);
            timer = 0;

            if (timeNextSpawn < 2)      //ускоряем движение шаров если время спавна меньше 2х сек
                speedMove += 0.1f;

            if(timeNextSpawn > 1)       //делаем меньше время спавна пока не будет 1 сек
                timeNextSpawn -= 0.05f;

            if (score >= 50)            //победа если набрать 50 очков
                LoseOrWin("You Win");

        }
	}

    public void ButtonReStart()
    {
        panelLose.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void LoseOrWin(string text)
    {
        Time.timeScale = 0;
        textLoseOrWin.text = text;
        panelLose.SetActive(true);
    }
}
