using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
    //腐蚀 近战T4
    /*
	 -10%伤害
	 -10%大小
	 */
    public class PreFixedMeleeRubbish : ModPrefix
    {

        public virtual float Power => 1f;

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 1.77f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult -= 0.20f * Power;
            scaleMult -= 0.1f * Power;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.5f * Power;
        }

        public override void Apply(Item item)
        {
        }
    }
}
