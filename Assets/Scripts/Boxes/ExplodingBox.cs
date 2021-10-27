using UnityEngine;

public class ExplodingBox : CoreBox
{
    public bool isCrossExplode;
    public float ExplosionRadius;
    public int Score;

    private readonly Vector2[] directions = new[]
        { new Vector2(0, 1), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, -1) };

    private void Start()
    {
        ScoreForDestroy = Score;
        IsUnbreakable = false;
        IsExploding = true;
    }


    public override void Explode()
    {
        if (isCrossExplode)
        {
            for (int i = 0; i < directions.Length; i++)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directions[i], ExplosionRadius);
                for (int j = 0; j < hits.Length; j++)
                {
                    if (hits[j].collider.gameObject.TryGetComponent(out ExplodingBox expBox))
                    {
                        DestroyBox();
                        expBox.Explode();
                    }
                    else if (hits[j].collider.gameObject.TryGetComponent(out CoreBox box))
                    {
                        box.DestroyBox();
                    }
                }
            }
        }
        else
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius / 2);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.TryGetComponent(out ExplodingBox expBox))
                {
                    DestroyBox();
                    expBox.Explode();
                }
                else if (colliders[i].gameObject.TryGetComponent(out CoreBox box))
                {
                    box.DestroyBox();
                }
            }
        }
    }
}