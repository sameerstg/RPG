using UnityEngine;



 
    public class PlayerSO : ScriptableObject
    {
        
        [field: SerializeField] public PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
        public Abiblities abilities;

}
