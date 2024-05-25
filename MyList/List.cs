using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg = null;
        Point<T>? end = null;
        int count = 0;
        public int Count => count;
        public MyList() { }
        public MyList(int size)
        {
            if (size <= 0) throw new Exception("Размер меньше 0");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void Print()
        {
            if (count == 0)
                Console.WriteLine("Список пуст");
            Point<T>? current = beg;
            for (int i = 1; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public Point<T> FindItem(T item)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data является null!");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public bool AddAfter(T itemToFind, T itemToAdd)
        {
            Point<T> pos = FindItem(itemToFind);
            if (pos == null)
                return false;
            count++;
            Point<T> newItem = new Point<T>(itemToAdd);
            newItem.Next = pos.Next;
            newItem.Pred = pos;
            pos.Next = newItem;

            if (newItem.Next != null)
            {
                newItem.Next.Pred = newItem;
            }
            else
            {
                end = newItem;
            }
            return true;
        }

        public void RemoveEvenItems()
        {
            if (beg == null || count == 1)
            {
                Console.WriteLine("В списке нет чётных элементов для удаления.");
                return;
            }
            Point<T>? current = beg;
            int index = 1;
            while (current != null)
            {
                Point<T>? next = current.Next;
                if (index % 2 == 0)
                {
                    if (current.Pred == null)
                    {
                        beg = next;
                        if (beg != null) beg.Pred = null;
                    }
                    else if (current.Next == null)
                    {
                        end = current.Pred;
                        if (end != null) end.Next = null;
                    }
                    else
                    {
                        Point<T> pred = current.Pred;
                        pred.Next = next;
                        next.Pred = pred;
                    }
                    count--;
                }
                index++;
                current = next;
            }
        }

        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public MyList<T> Clone()
        {
            MyList<T> clonedList = new MyList<T>();
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data is ICloneable)
                {
                    clonedList.AddToEnd((T)((ICloneable)current.Data).Clone());
                }
                current = current.Next;
            }
            return clonedList;
        }

        public void Clear()
        {
            beg = end = null;
            count = 0;
        }

        public Point<T> GetBeging()
        {
            return beg;
        }

        public bool Contains(T item)
        {
            Point<T> current = beg;
            while (current != null)
            {
                if (current.Data != null && current.Data.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }
    }
}