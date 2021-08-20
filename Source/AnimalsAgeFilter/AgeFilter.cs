using Verse;

namespace AnimalsAgeFilter
{

    public abstract class SpecialThingFilterWorker_AllowStage : SpecialThingFilterWorker
    {
        private string[] targetStages;

        protected SpecialThingFilterWorker_AllowStage(string[] targetStages)
        {
            this.targetStages = targetStages;
        }

        protected SpecialThingFilterWorker_AllowStage(string targetStage)
        {
            this.targetStages = new string[] { targetStage };
        }

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            foreach (string targetStage in targetStages)
            {
                if (pawn.ageTracker.CurLifeStage.defName == targetStage) return true;
            }
            return false;
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowStageBaby : SpecialThingFilterWorker_AllowStage
    {
        public SpecialThingFilterWorker_AllowStageBaby() : base(new string[] { "AnimalBaby", "AnimalBabyTiny" }) { }
    }

    public class SpecialThingFilterWorker_AllowStageJuvenile : SpecialThingFilterWorker_AllowStage
    {
        public SpecialThingFilterWorker_AllowStageJuvenile() : base("AnimalJuvenile") { }
    }

    public class SpecialThingFilterWorker_AllowStageAdult : SpecialThingFilterWorker_AllowStage
    {
        public SpecialThingFilterWorker_AllowStageAdult() : base("AnimalAdult") { }
    }

}
