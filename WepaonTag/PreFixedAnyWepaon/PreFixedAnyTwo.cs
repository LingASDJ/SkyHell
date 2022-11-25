using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag.PreFixedWepaon
{
	//射手传说词条 概率5%
	public class PreFixedAnyTwo : ModPrefix
	{

		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Ranged;

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override float RollChance(Item item)
		{
			return 0.05f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			shootSpeedMult *= 1 + 0.65f;
			critBonus += 24;
			damageMult *= 1 + 0.45f;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 2f + 0.5f * Power;
		}

		public override void Apply(Item item)
		{
		}
	}
}
