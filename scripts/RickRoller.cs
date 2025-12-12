using AO;

namespace Assembly.scripts;

public class RickRoller : Component
{
    [Serialized] public Interactable Interactable;

    public override void Awake()
    {
        Interactable.OnInteract += p =>
        {
            if (!p.IsLocal)
                return;

            Notifications.Show("Not yet!");
            SFX.Play(Assets.GetAsset<AudioAsset>("SFX/rick-roll.wav"), new SFX.PlaySoundDesc() { Positional = false, Volume = 0.4f });
        };
    }
}