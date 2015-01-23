using UnityEngine;
using System.Collections;

public class Boxer : MonoBehaviour {

    public GameObject diaBox;
    private DialogManager diaCtrl;
    public HeroControl hero;
    public baddie enemy;
    public int inBox = 0;

	// Use this for initialization
	void Start ()
    {
        if(this.transform.tag == "hero")
        {
            hero = GetComponentInParent<HeroControl>();
            diaCtrl = diaBox.GetComponent<DialogManager>();
        }
        else
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "wall" || other.transform.tag == "baddie")
        {
            inBox = 1;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        inBox = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "baddie" && this.transform.tag == "hero")
        {
            enemy = other.gameObject.GetComponent<baddie>();
            hero.inBattle = true;
            diaCtrl.StartCoroutine("BattleCall", enemy);
        }
        else
        {

        }
    }
}
