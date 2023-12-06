using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBar;
    public HealthBar healthBarScript;

    public ParticleSystem blood;
    public GameObject bloodParticles;

    private GameObject sword;

    private GoblinSFX GoblinSFX;

    
    // Start is called before the first frame update
    void Start()
    {
        GoblinSFX = gameObject.GetComponent<GoblinSFX>();

        healthBar = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;     
        healthBarScript = healthBar.GetComponent<HealthBar>();

        maxHealth = Random.Range(20, 100);
        health = maxHealth;
        healthBarScript.SetMaxHealth(maxHealth);

        sword = GameObject.Find("Sword");

        bloodParticles = GameObject.Find("Blood Particles");
        blood = bloodParticles.GetComponent<ParticleSystem>();

        
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
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
                
                
            }

        }

    }

    private void takeDamage(float damage)
    {
        blood.transform.position = transform.position;
        blood.Play();

        health -= damage;
        healthBarScript.SetHealth(health);

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
