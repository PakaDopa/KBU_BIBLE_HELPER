using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    public void Play(GameObject particleObject)
    {
        //setting positioon
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        particleObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        
        //particleObject.GetComponent<ParticleSystem>().Stop();
        particleObject.GetComponent<ParticleSystem>().Play();
    }
    public override void Init()
    {
        Debug.Log("Particle System Init Complete!");
    }
}