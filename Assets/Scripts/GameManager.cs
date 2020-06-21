using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    

    [Header("Class refrence")]
    [SerializeField] TextMeshProUGUI scoreText;


    [Header("UI bullet remaining")]
    [SerializeField] Image[] bulletRemainings;
    [SerializeField] Sprite emptyBullet;
    [SerializeField] Sprite fullBullet;
    [SerializeField] public int totalNumberOfBullet = 4;
    [SerializeField] GameObject bulletPrefeb = null;
    [SerializeField] public GameObject mangoes = null;
    [SerializeField] int totalNumberOfMango;
    [SerializeField] int maximumLevelNumber = 21;


    [Header("Game Conditions")]
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;



    public int bulletTurnNumber = 1;
    public float score = 0;


    private Bullet  bul;
    private bool doWeNeedToGetBulletComponent = true;
    private bool isReachedLevelIncremented;



    void Awake()
    {

        totalNumberOfMango = mangoes.transform.childCount;
        scoreText.text = ("Collected : " + score.ToString());

        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

      
    }


    void Start()
    {
        isReachedLevelIncremented = false;
        Debug.Log(" Game manager :: At start = " +PlayerPrefsController.GetLevelReached());
    }




    void Update()
    {
        score = (totalNumberOfMango - GameObject.Find("Mangoes").transform.childCount);
        scoreText.text = ("Collected : " + score.ToString());

        // instantiate next bullet when first bullet get damages
        if (doWeNeedToGetBulletComponent)
        {
            BulletInstantiateByCondition();

        }

        if (bul.isBulletReleased)
        {
            if (bulletTurnNumber < totalNumberOfBullet)
            {
                InstantiateNextBullet();
                bulletTurnNumber += 1;
            }
            else
            {
                doWeNeedToGetBulletComponent = false;
            }
            bul.isBulletReleased = false;
            Destroy(bul.gameObject);
           
        }

        if (!isReachedLevelIncremented) {
           CheckingForGameLoseAndWinConditions();
        }
       

        BulletUIInstantiationForRemaining();
     


    }

    void CheckingForGameLoseAndWinConditions()
    {

       
        if (GameObject.Find("Mangoes").transform.childCount == 0)
        {
               // load next level and level completed
               int levelR = PlayerPrefsController.GetLevelReached();
                winCanvas.SetActive(true);
                Debug.LogError("GameManager :: Congratulation you win level number = " + levelR);
                if (levelR < maximumLevelNumber)
                {
                     PlayerPrefsController.SetLevelReached((levelR + 1));
                }
                isReachedLevelIncremented = true;
        }
       
        if (bulletTurnNumber > totalNumberOfBullet || !FindObjectOfType<Bullet>())
        {
            if (score != totalNumberOfMango)
            {
                // load the same level and level failed
                int levelR = PlayerPrefsController.GetLevelReached();
                Debug.Log("GameManager :: loading the same level number = " + levelR);
                loseCanvas.SetActive(true);
            }
        }

    }

   
    private void BulletInstantiateByCondition() 
    {
         bul = FindObjectOfType<Bullet>();
    }







    private void BulletUIInstantiationForRemaining()
    {
        for (int i = 0; i < bulletRemainings.Length; i++)
        {
            if (i >= bulletTurnNumber)
            {
                bulletRemainings[i].sprite = fullBullet;
            }
            else
            {
                bulletRemainings[i].sprite = emptyBullet;
            }


            if (i < totalNumberOfBullet)
            {
                bulletRemainings[i].enabled = true;
            }
            else
            {
                bulletRemainings[i].enabled = false;
            }
        }
    }









  public void InstantiateNextBullet()
  {
        if (bulletTurnNumber <= totalNumberOfBullet)
        {
            if (bulletPrefeb != null)
            {
                Instantiate(bulletPrefeb, bulletPrefeb.transform.position, Quaternion.identity);
            }
        }
  }















}
