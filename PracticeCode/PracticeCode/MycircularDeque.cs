using System;
namespace homework1
{
    public class MycircularDeque
    {
        private int _front;
        private int _tail;
        private int _dequeLen;
        private int[] _arr;


        public MycircularDeque(int k)
        {
            _dequeLen = k + 1;
            _arr = new int[_dequeLen];

            _front = 0;
            _tail = 0;
        }

        public bool InsertFront(int value)
        {
            if(!IsFull())
            {
                this._arr[_front] = value;
                this._front = (_front - 1 ) % _dequeLen;
                return true;
            }
            return false;
        }

        /** Adds an item at the rear of Deque. Return true if the operation is successful. */
        public bool InsertLast(int value)
        {
            if(!IsFull())
            {
                this._arr[_tail] = value;
                this._tail = (_tail + 1) % _dequeLen;
                return true;
            }
            return false;

        }

        /** Deletes an item from the front of Deque. Return true if the operation is successful. */
        public bool DeleteFront()
        {
            if(!IsFull())
            {
                _front = (_front + 1) % _dequeLen;
                return true;
            }

            return false;

        }

        /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
        public bool DeleteLast()
        {
            if(!IsFull())
            {
                _tail = (_tail - 1) % _dequeLen;
                return true;
            }
            return false;

        }

        /** Get the front item from the deque. */
        public int GetFront()
        {
            if (!IsEmpty())
            {
                return this._arr[this._front];
            }
            return -1;

        }

        /** Get the last item from the deque. */
        public int GetRear()
        {
            if(!IsEmpty())
            {
                return this._arr[this._tail];
            }
            return -1;
        }

        /** Checks whether the circular deque is empty or not. */
        public bool IsEmpty()
        {
            return this._tail == this._front;

        }

        /** Checks whether the circular deque is full or not. */
        public bool IsFull()
        {
           return this._tail + 1 % _dequeLen == this._front;
        }
    }
}
