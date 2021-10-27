using UnityEngine;

public class SimpleBox : CoreBox
{
    public int SetHealth;
    public Color[] Colors;
    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        ChangeTexture(Health);
    }

    private void Start()
    {
        ScoreForDestroy = 1;
        Health = SetHealth;
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
