using System;
using System.IO;

public class FilePolicySource 
{
    public string GetPolicyFromSource() 
    {
        return File.ReadAllText("policy.json");
    }
}