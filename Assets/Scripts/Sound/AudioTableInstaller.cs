using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AudioTableInstaller", menuName = "Installers/AudioTableInstaller")]
public class AudioTableInstaller : ScriptableObjectInstaller<AudioTableInstaller>
{
    [SerializeField]
    private AudioTable _audioTable = default;

    public override void InstallBindings()
    {
        Container
            .BindInstance(_audioTable);
    }
}
