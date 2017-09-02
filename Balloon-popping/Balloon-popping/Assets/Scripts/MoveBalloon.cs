using UnityEngine;

public class MoveBalloon : MonoBehaviour
{
    public GameControl gameControl;
    
    void Start()
    {
        gameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
    }

    void Update()
    {
        gameObject.transform.Translate(Vector2.up * Time.deltaTime * gameControl.speedMove);

        if (gameObject.GetComponent<RectTransform>().localPosition.y > 800)
        {
            gameControl.LoseOrWin("You Lose");
        }
    }
    
}