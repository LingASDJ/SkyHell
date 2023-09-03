using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
    //起源 魔法T1
    /*
	 +48%暴击率
	 +35%速度
	 +5%击退力
	 -9%魔力花费
	 */
    public class PreFixedMagicGood : ModPrefix
    {

        public virtual float Power => 1f;

        public override PrefixCategory Category => PrefixCategory.Magic;

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override float RollChance(Item item)
        {
            return 1.4f;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult -= 0.35f * Power;
            manaMult *= 0.91f * Power;
            critBonus += 48;
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
