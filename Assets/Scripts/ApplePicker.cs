using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottom = -14f;
    public float basketSpacing = 2f;
    public List<GameObject> basketList;
    public GameObject endMessage;
    public static bool isGameOver = false;

    public Text nameGT;

    void Start()
    {
        basketList = new List<GameObject>();
        for(int i = 0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottom + (basketSpacing * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    private void Update()
    {
        if(isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                isGameOver = false;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach(GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        if (!isGameOver)
        {
            int basketIndex = basketList.Count - 1;
            GameObject tbasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tbasketGO);
        }

        if(basketList.Count == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        endMessage.SetActive(true);
        isGameOver = true;
        MainManager.Instance.SaveInfo();
    }
}
