using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBangumi.Core.Models;
public class Result<T>
{
    public bool IsComplete => _isComplete;
    public bool IsError => !_isComplete;

    private readonly bool _isComplete;
    private readonly T _data;
    private readonly string _message;

    public Result<T> OnComplete(Action<T> func)
    {
        if (_isComplete)
        {
            func(_data);
        }
        return this;
    }
    public Result<T> OnError(Action<string> func)
    {
        if (!_isComplete)
        {
            func(_message);
        }
        return this;
    }

    private Result(T data)
    {
        _isComplete = true;
        _data = data;
    }

    private Result(string message)
    {
        _isComplete = false;
        _message = message;
    }

    public static Result<T> Complete(T result)
    {
        return new Result<T>(result);
    }

    public static Result<T> Error(string message)
    {
        return new Result<T>(message);
    }
}