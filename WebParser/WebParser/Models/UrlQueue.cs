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
        private Queue queue;
        public UrlQueue()
        {
           queue = new Queue();

        }

        public List<String> OperateOnQueue(string lastUrl)
        {
            if (queue.Count < 5)
            {
                queue.Enqueue(lastUrl);
            }
            else
            {
                queue.Dequeue();
                queue.Enqueue(lastUrl);
            }
            lista.Clear();
            foreach (var a in queue)
            {
                lista.Add(a.ToString());
            }
            return lista;
        }
    }
}