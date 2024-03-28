using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate
    {
        string Info();
        void Enter();
        void Exit();
        void Update();
    }

