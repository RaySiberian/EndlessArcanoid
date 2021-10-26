using UnityEngine;

public abstract class CoreBox : MonoBehaviour
{
    public int Health { get; set; }
    public int Durability { get; set; }
    public int ScoreForDestroy { get; set; }
    public bool IsUnbreakable;
    public bool IsExploding;
    
    public virtual void DestroyBox()
    {
        if (IsUnbreakable)
        {
            return;
        }
        
        Data.Score += ScoreForDestroy;
        Destroy(gameObject);
    }

    public virtual void Hit()
    {
        if (IsUnbreakable)
        {
            return;
        }
        else if (IsExploding)
        {
            Explode();
        }

        if (Health > 0)
        {
            Health--;
            ChangeTexture(Health);
        }
        if (Health <= 0)
        {
            DestroyBox();
        }
        
    }

    public virtual void Move()
    {
        
    }
    
    public virtual void Explode(){}
    public virtual void ChangeTexture(int heath){}
    
}
