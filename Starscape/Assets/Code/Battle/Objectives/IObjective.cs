using UnityEngine;
using System.Collections;

interface IObjective
{
    bool Completed {get; set; }
    bool Failed { get; set; }
    void CheckCompletion();
    void CheckFailure();
}
