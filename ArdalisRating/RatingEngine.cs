using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using MohamedRating;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; } 
        public ConsoleLogger logger { get; set; } = new ConsoleLogger(); 
        public FilePolicySource policySource { get; set; } = new FilePolicySource();
        public PolicySerialzar policySerialzar { get; set; } = new PolicySerialzar();
        public RaterFactory factory { get; set; } = new RaterFactory();

        public void Rate()
        {
            logger.Log("Starting rate.");
            logger.Log("Loading policy.");

            string policyJson = policySource.GetPolicyFromSource();

            var policy = policySerialzar.GetPolicyFromJsonString(policyJson);

            var rater = factory.CreateUsingReflection(policy, this);
            rater.Rate(policy);
            logger.Log("Rating completed.");
        }
    }
}
