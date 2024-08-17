using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfigData", menuName = "Datas/Config Data")]
public sealed class ConfigData : ScriptableObject
{

    [field : SerializeField, Header("Player settings")] public Vector3 PlayerMaxSpeedVelocity { get; private set; }
    [field : SerializeField] public float PlayerMoveSpeed { get; private set; }
    [field : SerializeField] public float PlayerShakeCameraDurationAfterShoot { get; private set; }
    [field : SerializeField] public bool NavMeshAgentMovingType { get; private set; }

    //[field : SerializeField, Header("Hub settings")] public HubBase HubBase { get; private set; }
    [field : SerializeField] public ParticleSystem PlayerTeleportationEffect { get; private set; }
    [field : SerializeField] public Vector3 SpawnOffsetPlayerTeleportationEffect { get; private set; }
    [field : SerializeField, Header("Audio settings")] public List<AudioClip> AudioClipsInBattle { get; private set; }
    [field: SerializeField] public List<AudioClip> AudioClipsOnHub { get; private set; }
    [field: SerializeField] public AudioClip TeleportationStartEffect { get; private set; }
    [field: SerializeField] public AudioClip TeleportationCompetedEffect { get; private set; }
    [field: SerializeField] public float AudioTransitionInDuration { get; private set; }
    [field: SerializeField] public float AudioTransitionOutDuration { get; private set; }

    [field: SerializeField, Header("Level settings")] public float TranstionIslandDurationForStartBattle { get; private set; }
    //[field: SerializeField] public Chest RewardTreasure { get; private set; }
    [field: SerializeField] public float SpawnTreasureDistanceOffsetByPlayer { get; private set; }
    [field: SerializeField] public float OriginRewardMoney { get; private set; }
    [field: SerializeField] public float RewardMoneyPerLevel { get; private set; }

    //[field: SerializeField, Header("Enemies settings")] public List<Enemy> Enemies { get; private set; }
    //[field: SerializeField, Header("Damage Text UI settings")] public DamageText DamageText { get; private set; }
    [field: SerializeField] public float DamageTextScalingDuration { get; private set; }
    [field: SerializeField] public Ease DamageTextEase { get; private set; }

    [field: SerializeField, Header("Other settings")] public bool CursorEnable { get; private set; }
    [field: SerializeField, Header("Parallax Effect settings")] public float WorldScalingDuration { get; private set; }
    [field: SerializeField] public float OffsetYTeleportationOnWorld { get; private set; }
    [field: SerializeField] public Vector3 OffsetRaycastPlayer { get; private set; }

    [field: SerializeField, Header("Debug settings")] public bool DebugMode { get; private set; }
}
