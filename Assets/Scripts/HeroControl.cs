using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HeroControl : MonoBehaviour {
    
    //Dialog Controllers 
    public DialogManager diaCtrl;
    public Text displayDialog;
    public Text heroInfo;
    public bool button = false;
    public float timer;

    //Collsion Controllers
    public GameObject North;
    public Boxer CNorth;
    public GameObject East;
    public Boxer CEast;
    public GameObject South;
    public Boxer CSouth;
    public GameObject West;
    public Boxer CWest;

    //Enemy Grabber & Battle controls
    public bool inBattle = false;
    public List<baddie> baddieList = new List<baddie>();

    //Hero Stats
    public int LVL;
    public int EXP;
    public int HP;
    public int MP;
    public int attack;
    public int magic; 
    public int defense;


	// Use this for initialization
	void Start () 
    {
	    CNorth = North.GetComponent<Boxer>();
        CEast = East.GetComponent<Boxer>();
        CSouth = South.GetComponent<Boxer>();
        CWest = West.GetComponent<Boxer>();

	}
	
	// Update is called once per frame
    void Update()
    {
        heroInfo.text = "Level:" + LVL + " HP:" + HP + " MP:" + MP;

        //Movement Control
        if (inBattle == true)
        {

        }
        else if (baddieList.Count == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (CNorth.inBox == 1)
                {

                }
                else
                {
                    transform.Translate(0.0f, 1.0f, 0.0f);
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (CEast.inBox != 1)
                {
                    transform.Translate(1.0f, 0.0f, 0.0f);
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (CSouth.inBox != 1)
                {
                    transform.Translate(0.0f, -1.0f, 0.0f);
                }

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (CWest.inBox != 1)
                {
                    transform.Translate(-1.0f, 0.0f, 0.0f);
                }

            }
        }

    }

        public void moveNorth()
        {
            if(CNorth.inBox != 1 && !inBattle)
            {
                transform.Translate(0.0f, 1.0f, 0.0f);
            }
        }

        public void moveEast()
        {
            if (CEast.inBox != 1 && !inBattle)
                {
                    transform.Translate(1.0f, 0.0f, 0.0f);
                }
        }

        public void moveSouth()
        {
            if (CSouth.inBox != 1 && !inBattle)
                {
                    transform.Translate(0.0f, -1.0f, 0.0f);
                }
        }

        public void moveWest()
        {
            if (CWest.inBox != 1 && !inBattle)
                {
                    transform.Translate(-1.0f, 0.0f, 0.0f);
                }
        }


        
	}
