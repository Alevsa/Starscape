using UnityEngine;
using System.Collections;

interface IObjective
{
    bool Active { get; set; }
    bool Completed {get; set; }
    bool Failed { get; set; }
    string DescriptiveName { get; set; }
    void CheckCompletion();
    void CheckFailure();
    void Activate();
}
