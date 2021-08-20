using RimWorld;
using Verse;

namespace AnimalsAgeFilter
{
    public class SpecialThingFilterWorker_AllowSterilized : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }
            return pawn.health.hediffSet.HasHediff(HediffDefOf.Sterilized);
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotSterilized : SpecialThingFilterWorker
    {
        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }
            return !pawn.health.hediffSet.HasHediff(HediffDefOf.Sterilized);
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}
