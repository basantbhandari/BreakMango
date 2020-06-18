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


    [Header("Game Conditions")]
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;



    public int bulletTurnNumber = 1;
    public float score = 0;
    private Bullet bulletObjInGameManager = new Bullet();
    private MenuManager menuManagerObjectInGameManager = new MenuManager();


    private Bullet  bul;
    private bool doWeNeedToGetBulletComponent = true;
    private float timeInSecondBetweenCollionToDestructionOfTarget = 7f;
    private float timeInSecondBetweenTwoUIScaleAnimation = 3f;



    void Awake()
    {

        totalNumberOfMango = mangoes.transform.childCount;
        scoreText.text = ("Collected : " + score.ToString());

        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);

    }





    void Update()
    {
 

        score = (totalNumberOfMango - GameObject.Find("Mangoes").transform.childCount);
        scoreText.text = ("Collected : " + score.ToString());
        Debug.LogError("Score = " + score);


        // instantiate next bullet when first bullet get damages
        if (doWeNeedToGetBulletComponent)
        {
            BulletInstantiateByCondition();
        }
        
        Debug.Log("From GameManager update function and isBulletReleased: " + bul.isBulletReleased);
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
            
            Destroy(bul.gameObject);
            bul.isBulletReleased = false;
           
        } 
        
        if (bulletTurnNumber >= totalNumberOfBullet && !FindObjectOfType<Bullet>())
        {
            // checking for number of mango destroyed and remaining;

            if (GameObject.Find("Mangoes").transform.childCount == 0)
            {
                // load next level and level completed
                Debug.LogError("load next level");
                //menuManagerObjectInGameManager.LoadLevel_First();
                winCanvas.SetActive(true);

            }
            else
            {
                // load the same level(retry) and level failed
                Debug.LogError("load the same level(retry)");
                //menuManagerObjectInGameManager.LoadLevel_First();
                loseCanvas.SetActive(true);
            }

        }


       

        BulletUIInstantiationForRemaining();
        Debug.LogWarning("bullet turn number = "+ bulletTurnNumber);






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
        // instantiate new bullet at hook position
        if (bulletTurnNumber <= totalNumberOfBullet)
        {
            if (bulletPrefeb != null)
            {
                Instantiate(bulletPrefeb, bulletPrefeb.transform.position, Quaternion.identity);
            }
        }
  }















}
