using System;
using System.Collections.Generic;

public interface StateBase
{
    void EnterExcute();
    //每帧执行
    void Excute();
    void ExitExcute();
}

