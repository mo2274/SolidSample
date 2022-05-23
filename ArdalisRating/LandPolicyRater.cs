using System;
using ArdalisRating;

namespace MohamedRating
{
    public class LandPolicyRater : Rater
    {
        private readonly RatingEngine engine;
        private readonly ConsoleLogger logger;

        public LandPolicyRater(RatingEngine engine, ConsoleLogger logger)
        {
            this.engine = engine;
            this.logger = logger;
        }

        public override void Rate(Policy policy) 
        {
            logger.Log("Rating AUTO policy...");
            logger.Log("Rating LAND policy...");
            logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                logger.Log("Insufficient bond amount.");
                return;
            }
            engine.Rating = policy.BondAmount * 0.05m;
        }

    }
}