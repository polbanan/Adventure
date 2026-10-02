using UnityEngine;

public interface IState
{
    void Enter(); // для вкючения состояния
    void Update(); // для отслеживания не пора ли ли сменить состояние
    void FixedUpdate(); // физическое перемещение
    void Exit(); // для выхода из состояния

}
