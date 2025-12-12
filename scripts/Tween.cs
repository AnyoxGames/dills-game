using AO;

namespace Assembly.scripts;

public class Tween : Component
{
    public static void Scale(Entity targetEntity, Vector2 targetScale, float totalDuration, Func<float, float> easeFunction)
    {
        targetEntity.AddComponent<Tween>(e =>
        {
            Vector2 startScale = targetEntity.Scale;
            e.Duration = totalDuration;
            e.Callback += x => targetEntity.Scale = Vector2.Lerp(startScale, targetScale, easeFunction(x));
        });
    }
    
    private float ElapsedTime;
    private float Duration;
    private Action<float> Callback;

    public override void Update()
    {
        Callback.Invoke(ElapsedTime / Duration);
        ElapsedTime += Time.DeltaTime;

        if (ElapsedTime < Duration)
            return;
        
        Callback.Invoke(1f);
        Entity.RemoveComponent(this);
    }
}