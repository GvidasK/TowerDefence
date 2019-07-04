using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider meshas;
    [SerializeField] int EnemyGyvybes = 3;
    [SerializeField] ParticleSystem hitoParticle;
    [SerializeField] ParticleSystem mirtiesParticle;
    [SerializeField] Vector3 EnemySpawnTaskas;
    [SerializeField] GameObject NaujasEnemy;
    bool PasibaigePriesoGyvybes = false;

    // Use this for initialization
    void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        //print("Pasove");
        hitas();
    }

    private void hitas()
    {
        EnemyGyvybes = EnemyGyvybes - 1;
        print(EnemyGyvybes);
        hitoParticle.Play();
        if (EnemyGyvybes == 0)
        {
            PasibaigePriesoGyvybes = true;
            var mfx = Instantiate(mirtiesParticle, transform.position, Quaternion.identity);
            mfx.Play();
            GameObject.Destroy(this.gameObject);
            print("pasibaige prieso gyvybes");
        }
        /*if (PasibaigePriesoGyvybes == true)
        {
            EnemySpawn();
        }

    }
}
public void EnemySpawn()
{
    Instantiate(NaujasEnemy, transform.position, transform.rotation);

}*/

    }

}


