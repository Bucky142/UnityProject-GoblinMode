using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public HealthBar healthBarScript;

    public ParticleSystem bloodParticles;
    public GameObject bloodObject;

    private GoblinSFX GoblinSFX;

    private GameObject killCountPanel;
    private SetKillCount setKillCount;


    // Start is called before the first frame update
    void Start()
    {
        GoblinSFX = gameObject.GetComponent<GoblinSFX>();

        healthBar = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;     
        healthBarScript = healthBar.GetComponent<HealthBar>();

        maxHealth = Random.Range(20, 100);
        health = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);

        bloodObject = GameObject.Find("Blood Particles");
        bloodParticles = bloodObject.GetComponent<ParticleSystem>();

        killCountPanel = GameObject.Find("KillCountPanel");
        setKillCount = killCountPanel.GetComponent<SetKillCount>();
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        // handles damage and enemy death
        if (collision.gameObject.tag == "hitBox")
        {

            SwordVelocity swordVelocity = collision.GetComponent<SwordVelocity>();

            int magnitudeOfVelocity = swordVelocity.magnitudeOfVelocity;

            //Debug.Log(magnitudeOfVelocity);

            if (magnitudeOfVelocity > 20)
            {
                takeDamage(20);              
            }
            

            if (health <= 0)
            {
                GoblinSFX.DeathSFX();
                setKillCount.IncrementCounter();
            }
        }

    }

    private void takeDamage(float damage)
    {
        //generates blood 
        bloodObject.transform.position = transform.position;
        bloodParticles.Play();
        //manages health
        health -= damage;
        healthBarScript.SetHealth(health);
        //manages hit sound
        GoblinSFX.HitSFX();
    }










    //void Collision(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "hitBox")
    //    {
    //        Vector3 oldPosition = collision.gameObject.transform.position;
    //        Vector2 collisionVelocity = collision.gameObject.transform.position - oldPosition / Time.fixedDeltaTime;

    //        if (collisionVelocity.magnitude > deathVelocity)
    //        {
    //            Destroy(gameObject);
    //        }
            
    //    }

    //}

    
}
