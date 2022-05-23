using System;
using ArdalisRating;

namespace MohamedRating
{
    public class RaterFactory 
    {
        public Rater Create(Policy policy, RatingEngine engine) 
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine, engine.logger);
                case PolicyType.Land:
                    return new LandPolicyRater(engine, engine.logger);
                case PolicyType.Life:
                    return new LifePolicyRater(engine, engine.logger);
                default:
                    return new Rater();
            }
        }

        public Rater CreateUsingReflection(Policy policy, RatingEngine engine) 
        {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"MohamedRating.{policy.Type}PolicyRater"), 
                new object[] {engine, engine.logger});
            }
            catch (System.Exception)
            {
               return new UnKnownPolicyRater(engine.logger);
            }
        }
    }
}