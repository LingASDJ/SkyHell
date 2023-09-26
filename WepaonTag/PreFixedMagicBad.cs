using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{

    public class PreFixedMagicBad : ModPrefix
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

        /*
		 -48%暴击率
		 -35%速度
		 +99%魔力花费
		-90%伤害
		 */

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult += 0.35f * Power;
            manaMult *= 1.25f * Power;
            critBonus -= 5;
            damageMult *= 0.6f;
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
