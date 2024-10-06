
namespace SunamoCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ResultWithExceptionCollections<T>
{
    public T Data { get; set; }




    public string exc { get; set; }
    public ResultWithExceptionCollections(T data)
    {
        Data = data;
    }
    public ResultWithExceptionCollections(string exc)
    {
        this.exc = exc;
    }
    public ResultWithExceptionCollections(Exception exc)
    {
        this.exc = Exceptions.TextOfExceptions(exc);
    }



    public ResultWithExceptionCollections()
    {
    }
}