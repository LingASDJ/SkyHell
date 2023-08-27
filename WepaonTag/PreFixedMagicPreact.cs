using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag
{
	//渊灵 魔法T0
	/*
	 +25%伤害
	 +18%暴击率
	 +15%速度
	 +20%击退力
	 -25%魔力花费
	 */
	public class PreFixedMagicPreact : ModPrefix
	{

		public virtual float Power => 1f;

        public override PrefixCategory Category => PrefixCategory.Magic;

        public override float RollChance(Item item)
		{
			return 1.57f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 1f + 0.25f * Power;
			useTimeMult -= 0.10f * Power;
			shootSpeedMult += 0.15f * Power;
			knockbackMult *= 1 + 0.20f * Power;
			manaMult *= 0.45f*Power;
			critBonus += 18;
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
