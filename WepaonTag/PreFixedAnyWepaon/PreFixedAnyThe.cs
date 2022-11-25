using Terraria;
using Terraria.ModLoader;

namespace SkyHell.WepaonTag.PreFixedWepaon
{
	//战士传说词条 概率5%
	public class PreFixedAnyThe : ModPrefix
	{

		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Melee;

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
			damageMult *= 1.95f * Power;
			useTimeMult -= 0.24f * Power;
			knockbackMult *= 1f + 0.45f * Power;
			scaleMult *= 1f + 0.5f * Power;
			critBonus += 27;
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
