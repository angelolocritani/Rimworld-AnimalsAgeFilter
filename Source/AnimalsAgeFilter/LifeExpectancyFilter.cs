using Verse;

namespace AnimalsAgeFilter
{
    public class SpecialThingFilterWorker_AllowOverLifeExpectancy : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return pawn.ageTracker.AgeBiologicalYearsFloat >= pawn.RaceProps.lifeExpectancy;
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotOverLifeExpectancy : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            return pawn.ageTracker.AgeBiologicalYearsFloat < pawn.RaceProps.lifeExpectancy;


        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }
}
