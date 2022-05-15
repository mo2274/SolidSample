using System;
using ArdalisRating;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class PolicySerialzar
{
    public Policy GetPolicyFromJsonString(string policyJson) 
    {
        return  JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
    }
}