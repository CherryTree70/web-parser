using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebParser.Models
{
    public class UrlQueue
    {
        List<String> lista = new List<string>();
        public Queue q;
        public UrlQueue()
        {
           q = new Queue();

        }

        public List<String> OperateOnQueue(string lastUrl)
        {
            if (q.Count < 5)
            {
                q.Enqueue(lastUrl);
            }
            else
            {
                q.Dequeue();
                q.Enqueue(lastUrl);
            }
            lista.Clear();
            foreach (var a in q)
            {
                lista.Add(a.ToString());
            }
            return lista;
        }
    }
}