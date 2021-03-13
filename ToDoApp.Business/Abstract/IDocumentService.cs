using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Business.Abstract
{
    public interface IDocumentService
    {
        //Geriye üretmiş ve upload etmiş olduğu pdf dosyasının virtual pathini döner.
        string TransferPdf<T>(List<T> list) where T:class,new();
        //Geriye excel verisini byte dizisi olarak döner.
        byte[] TransferExcel<T>(List<T> list) where T : class, new();

    }
}
