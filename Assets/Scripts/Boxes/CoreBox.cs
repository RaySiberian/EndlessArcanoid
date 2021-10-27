using System;
using UnityEngine;

public abstract class CoreBox : MonoBehaviour
{
    public int Health { get; set; }
    public int Durability { get; set; }
    public int ScoreForDestroy { get; set; }
    public bool IsUnbreakable;
    public bool IsExploding;
    public static event Action<CoreBox> OnBoxDestroy;

    public virtual void DestroyBox()
    {
        if (IsUnbreakable)
        {
            return;
        }
        
        Data.Score += ScoreForDestroy;
        OnBoxDestroy?.Invoke(this);
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
        var boxTransform = transform;
        var position = boxTransform.position;
        position = new Vector3(position.x, position.y - 0.5f);
        boxTransform.position = position;
    }
    
    public virtual void Explode(){}
    public virtual void ChangeTexture(int heath){}
    
}
