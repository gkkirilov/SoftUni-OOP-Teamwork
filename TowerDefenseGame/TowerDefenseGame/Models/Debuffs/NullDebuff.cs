namespace TowerDefenseGame.Models.Debuffs
{
    class NullDebuff : Debuff
    {
        public NullDebuff()
            : base(int.MaxValue, 0, 0)
        {
        }
    }
}
