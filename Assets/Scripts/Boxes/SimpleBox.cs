using UnityEngine;

public class SimpleBox : CoreBox
{
    [SerializeField] private int SetHeath;
    public Color[] Colors;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        ScoreForDestroy = 1;
        Health = SetHeath;
        Durability = 1;
        IsUnbreakable = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeTexture(Health);
    }

    public override void ChangeTexture(int health)
    {
        //Число 3 зависит от кол-ва текстур в массиве
        if (health <= 3 && health > 0)
        {
            spriteRenderer.color = Colors[health - 1];
        }
    }
}
