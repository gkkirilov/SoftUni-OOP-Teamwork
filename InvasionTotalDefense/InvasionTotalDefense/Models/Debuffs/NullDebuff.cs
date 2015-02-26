namespace TowerDefenseGame.Models.Debuffs
{
    public class NullDebuff : Debuff
    {
        public NullDebuff()
            : base(int.MaxValue, 0, 0)
        {
        }
    }
}
