namespace TowerDefenseGame.Models.Effects.Debuffs
{
    class NullDebuff : Debuff
    {
        public NullDebuff()
            : base(int.MaxValue, 0, 0)
        {
        }
    }
}
