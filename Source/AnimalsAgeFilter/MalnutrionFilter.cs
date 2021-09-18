using RimWorld;
using Verse;

namespace AnimalsAgeFilter
{
    public class SpecialThingFilterWorker_AllowMalnourished : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }
            return pawn.health.hediffSet.HasHediff(HediffDefOf.Malnutrition);
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotMalnourished : SpecialThingFilterWorker
    {
        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }
            return !pawn.health.hediffSet.HasHediff(HediffDefOf.Malnutrition);
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}
