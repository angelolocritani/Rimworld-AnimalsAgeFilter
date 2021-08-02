using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using RimWorld;
using UnityEngine;
using Verse;

namespace AnimalsAgeFilter
{
    public class AnimalsAgeFilterMod : Mod
    {
        public AnimalsAgeFilterMod(ModContentPack content) : base(content) { }
    }

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


    public class SpecialThingFilterWorker_AllowPregnant : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            CompEggLayer compEggLayer = pawn.TryGetComp<CompEggLayer>();
            if (compEggLayer != null)
            {
                // if can LayEgg
                return compEggLayer.FullyFertilized;
            }
            else
            {
                return pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant);
            }
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }

    public class SpecialThingFilterWorker_AllowNotPregnant : SpecialThingFilterWorker
    {

        public override bool Matches(Thing t)
        {
            Pawn pawn = t as Pawn;
            if (pawn == null)
            {
                return false;
            }

            CompEggLayer compEggLayer = pawn.TryGetComp<CompEggLayer>();
            if (compEggLayer != null)
            {
                return !compEggLayer.FullyFertilized;
            }
            else
            {
                return !pawn.health.hediffSet.HasHediff(HediffDefOf.Pregnant);
            }
        }

        public override bool CanEverMatch(ThingDef def)
        {
            return def.category == ThingCategory.Pawn;
        }
    }


}
