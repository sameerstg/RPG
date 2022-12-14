using UnityEngine;



    [CreateAssetMenu(fileName = "Player", menuName = "/Characters/Player")]
    public class PlayerSO : ScriptableObject
    {
        public string name;
        [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
        public Abiblities abilities;

}
