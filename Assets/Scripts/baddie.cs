using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class baddie : MonoBehaviour {

    //Collsion Controllers
    public GameObject North;
    private Boxer CNorth;
    public GameObject East;
    private Boxer CEast;
    public GameObject South;
    private Boxer CSouth;
    public GameObject West;
    private Boxer CWest;

    //Dialog Controllers 
    public Text displayDialog;

    //Baddie Stats
    public int enemyID;
    public int batChoice;
    public string name;
    public int EXP;
    public int HP;
    public int MP;
    public int movementSpeed;

    public HeroControl hero;
    public float timer;
    public int direction;

	// Use this for initialization
	void Start () 
    {

        CNorth = North.GetComponent<Boxer>();
        CEast = East.GetComponent<Boxer>();
        CSouth = South.GetComponent<Boxer>();
        CWest = West.GetComponent<Boxer>();
        hero.baddieList.Add(this);
	    //Setup Enemy based on enemyID
        if(enemyID == 1)
        {
            name = "Slime";
            EXP = 10;
            HP = 15;
            MP = 0;
        }
        if(enemyID == 2)
        {
            name = "Slime2";
            EXP = 10;
            HP = 15;
            MP = 0;
        }
        if(enemyID == 3)
        {
            name = "Reaper";
            EXP = 150;
            HP = 50;
            MP = 50;
        }
        if(enemyID == 10)
        {
            
        }
	}
	
	// Update is called once per frame
	void Update () 
    {

	    //Auto Random Movement
        if(hero.inBattle)
        {
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= movementSpeed)
            {
                direction = Random.Range(1, 5);
                if(direction == 1)
                {
                    if(CNorth.inBox == 0)
                    {
                        transform.Translate(0.0f, 1.0f, 0.0f);
                        timer = 0;
                    }
                    else
                    {

                    }
                }
                else if(direction == 2)
                {
                    if (CEast.inBox == 0)
                    {
                        transform.Translate(1.0f, 0.0f, 0.0f);
                        timer = 0;
                    }
                    else
                    {

                    }
                }
                else if(direction == 3)
                {
                    if(CSouth.inBox == 0)
                    {
                        transform.Translate(0.0f, -1.0f, 0.0f);
                        timer = 0;
                    }
                    else
                    {

                    }
                }
                else if(direction == 4)
                {
                    if(CWest.inBox == 0)
                    {
                        transform.Translate(-1.0f, 0.0f, 0.0f);
                        timer = 0;
                    }
                    else
                    {

                    }
                }
            }
        }

        

	}

    public int BattleChoice()
    {
        return Random.Range(1, 4);
    }
}
