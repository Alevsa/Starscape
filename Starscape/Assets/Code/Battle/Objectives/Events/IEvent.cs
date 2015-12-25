interface IEvent
{
    void Fire();
    void Activate();
    float TriggerTime { get; set; } 
}