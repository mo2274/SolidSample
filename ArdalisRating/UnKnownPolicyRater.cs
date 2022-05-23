using System;
using ArdalisRating;

namespace MohamedRating
{
    public class UnKnownPolicyRater : Rater
    {
        private readonly ConsoleLogger logger;

        public UnKnownPolicyRater(ConsoleLogger logger)
        {
            this.logger = logger;
        }

        public override void Rate(Policy policy) 
        {
            logger.Log("UnKnown Policy Type...");
        }

    }
}