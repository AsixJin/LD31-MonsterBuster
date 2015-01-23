using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogManager : MonoBehaviour {

    //Button Variables
    public int butChoice = 0;
    //Button #1
    public Button button1;
    public Text button1_Text;
    //Button #2
    public Button button2;
    public Text button2_Text;
    //Button #3
    public Button button3;
    public Text button3_Text;

    //Other Variables
    public GameObject player;
    private HeroControl hero;
    private int defPower = 0;
    private int heroAttack;
    private baddie enemy;

    Text display;
    public string dialog;
    public string enemyCounter;
    public Text enemyInfo;

	// Use this for initialization
	void Start () 
    {
        Screen.SetResolution(842, 468, false);
        hero = player.GetComponent<HeroControl>();
        //dialog = "Onward";
        display = this.GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        enemyCounter = hero.baddieList.Count + " monsters reaming!\nOnward!";      
        if(hero.inBattle == true)
        {
            display.text = dialog;
            enemyInfo.text = enemy.name + ": HP:" + enemy.HP;
        }
        else if(hero.baddieList.Count == 0)
        {
            display.text = "You have cleaned house!\nPress SPACE to play again";

        }
        else
        {
            enemyInfo.text = "";
            display.text = enemyCounter;
        }
	}

    public void Button1()
    {
        if(hero.inBattle == true)
        {
            butChoice = 1;
        }
       
    }

    public void Button2()
    {
        if(hero.inBattle == true)
        {
            butChoice = 2;
        }
        
    }

    public void Button3()
    {
        if(hero.inBattle == true)
        {
            butChoice = 3;
        }
       
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode) && !Input.GetKeyDown(KeyCode.Menu))
            yield return null;
    }

    IEnumerator DialogDisplay(int passCode)
    {
        if(passCode == 1)
        {    
            dialog = "Battle with " + enemy.name + " has begun!\nSelect your move & hit SPACE!";
            button1_Text.text = "Attack";
            button2_Text.text = "Magic";
            button3_Text.text = "Defend";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);           
            yield return StartCoroutine("OptionChooser");
        }
        if(passCode == 2)
        {     
            dialog = "Select your move & hit SPACE!";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            yield return StartCoroutine("OptionChooser");
        }
        if(passCode == 3)
        {        
            dialog = "No move selected!\nSelect your move & hit SPACE!";
            yield return StartCoroutine("OptionChooser");
        }
        if(passCode == 4)
        {
            heroAttack = Random.Range(1, hero.attack + 1);
            dialog = "Hero strikes!\nHero deals " + heroAttack + " dmg!";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            yield return StartCoroutine("AttackSeq");
        }
        if(passCode == 5)
        {
            dialog = "Hero cast magic!\nHero deals 10 dmg!";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            yield return StartCoroutine("MagicSeq");
        }
        if(passCode == 6)
        {
            dialog = "Hero prepares for enemy attack!";
            defPower = 2;
            enemy.batChoice = enemy.BattleChoice();
            yield return StartCoroutine("EnemySeq", enemy.batChoice);
        }
        if(passCode == 7)
        {
            dialog = "You have beaten " + enemy.name + "!\nYou've gained " + enemy.EXP + " experience!";
            yield return StartCoroutine("Victory", enemy.EXP);
        }
        if(passCode == 9)
        {
            dialog = "You have fallen!\nTry again!";
            yield return StartCoroutine("Defeat");
        }
        if(passCode == 10)
        {
            dialog = enemy.name + " thinks of a move";
            yield return new WaitForSeconds(0.5f);
            dialog += ".";
            yield return new WaitForSeconds(0.5f);
            dialog += ".";
            yield return new WaitForSeconds(0.5f);
            dialog += ".";
            enemy.batChoice = enemy.BattleChoice();
            yield return StartCoroutine("EnemySeq", enemy.batChoice);
        }
        if(passCode == 11)
        {
            dialog = "Not enough MP to cast!\nSelect your move & hit SPACE!";
            yield return StartCoroutine("OptionChooser");
        }
    }

    IEnumerator BattleCall(baddie x)
    {
        enemy = x;
        yield return StartCoroutine("DialogDisplay", 1);
       
    }

    IEnumerator OptionChooser()
    {
        yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);          
        if(butChoice == 0)
        {
            yield return StartCoroutine("DialogDisplay", 3);
        }
        else if(butChoice == 1)
        {
            yield return StartCoroutine("DialogDisplay", 4);
        }
        else if(butChoice == 2)
        {
            if(hero.MP >= 10)
            {
                yield return StartCoroutine("DialogDisplay", 5);
            }
            else
            {
                yield return StartCoroutine("DialogDisplay", 11);
            }
            
        }
        else if(butChoice == 3)
        {
            yield return StartCoroutine("DialogDisplay", 6);
        }
    }

    IEnumerator AttackSeq()
    {
        yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);    
        enemy.HP -= heroAttack;
        if(enemy.HP > 0)
        {
            defPower = 0;
            yield return StartCoroutine("DialogDisplay", 10);
            
        }
        else
        {
            yield return StartCoroutine("DialogDisplay", 7);
        }
    }
    IEnumerator MagicSeq()
    {
        yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
        hero.MP -= 10;
        enemy.HP -= 10;
        if (enemy.HP > 0)
        {
            defPower = 0;
            yield return StartCoroutine("DialogDisplay", 10);
        }
        else
        {
            yield return StartCoroutine("DialogDisplay", 7);
        }
    }
    /*
    IEnumerator DefenseSeq()
    {
        yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);

        if (enemy.HP >= 0)
        {
            enemy.batChoice = enemy.BattleChoice();
            yield return StartCoroutine("EnemySeq", enemy.batChoice);
        }
        else
        {
            yield return StartCoroutine("Victory", enemy.EXP);
        }
    }
     */ 

    IEnumerator EnemySeq(int choice)
    {
        int attackPower;
        if(enemy.batChoice == 1)
        {
            attackPower = Random.Range(1, 6);
            dialog = enemy.name + " deals " + (attackPower - defPower) + "  dmg!";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            hero.HP -= attackPower - defPower;
            if (hero.HP > 0)
            {
                yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
                yield return StartCoroutine("DialogDisplay", 2);
            }
            else
            {
                yield return StartCoroutine("DialogDisplay", 9);
            }

        }
        else if(enemy.batChoice == 2)
        {
            attackPower = Random.Range(5, 8);
            dialog = enemy.name + " lunges for " + (attackPower - defPower) + " dmg!";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            hero.HP -= attackPower - defPower;
            if (hero.HP > 0)
            {
                yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
                yield return StartCoroutine("DialogDisplay", 2);
            }
            else
            {
                yield return StartCoroutine("DialogDisplay", 9);
            }
        }
        else if(enemy.batChoice == 3)
        {
            dialog = enemy.name + " stands around...";
            yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
            if (hero.HP > 0)
            {
                yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
                yield return StartCoroutine("DialogDisplay", 2);
            }
            else
            {
                yield return StartCoroutine("DialogDisplay", 9);
            }
        }
    }

    IEnumerator Victory(int ExpGain)
    {
        yield return StartCoroutine("WaitForKeyDown", KeyCode.Space);
        hero.EXP += ExpGain;
        hero.inBattle = false;
        hero.baddieList.Remove(enemy);
        Destroy(enemy.gameObject);
        hero.CNorth.inBox = 0;
        hero.CSouth.inBox = 0;
        hero.CWest.inBox = 0;
        hero.CEast.inBox = 0;
        StopAllCoroutines();
    }
    IEnumerator Defeat()
    {
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel(Application.loadedLevel);
    }
   
}
