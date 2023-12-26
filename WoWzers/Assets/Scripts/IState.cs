using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Istate
    {
        void Enter();
        void Exit();
        void Update();
    }

