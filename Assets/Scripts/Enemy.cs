using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            //I hit the Player!
            whatIHit.GetComponent<Player>().LoseALife();
            GameObject.Find("GameManager").GetComponent<GameManager>().Loselife(-1);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Weapon")
        {
            //I am shot!
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }


        if (whatIHit.tag == "Coin")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnCoin(1);
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
