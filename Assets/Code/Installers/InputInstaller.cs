using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private float minimumSwipeMagnitude = 5.0f;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesTo<PlayerMobileInput>()
            .AsSingle()
            .WithArguments(minimumSwipeMagnitude);
    }
}