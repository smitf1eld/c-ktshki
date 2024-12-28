public class IntArrayList
{
    private int[] _buffer;
    private int _count;
    private int _arraySize;

    private const int DefaultArraySize = 2;
    public int Count => _count;
    public int ArraySize => _arraySize;

    public int this[int index]
    {
        get => _buffer[index];
        set => _buffer[index] = value;
    }

    public IntArrayList()
    {
        _arraySize = DefaultArraySize;
        _buffer = new int[_arraySize];
        _count = 0;
    }

    public IntArrayList(int initialArraySize)
    {
        _arraySize = Math.Max(initialArraySize, DefaultArraySize);
        _buffer = new int[_arraySize];
        _count = 0;
    }

    public void PushBack(int value)
    {
        if (_count == _arraySize)
        {
            _arraySize *= 2;
            int[] newBuffer = new int[_arraySize];
            Array.Copy(_buffer, newBuffer, _count);
            _buffer = newBuffer;
        }

        _buffer[_count] = value;
        _count++;
    }

    public void PopBack()
    {
        if (_count > 0)
        {
            _count--;
        }
    }

    public bool TryInsert(int index, int value)
    {
        if (index < 0 || index > _count)
        {
            return false;
        }

        if (_count == _arraySize)
        {
            _arraySize *= 2;
            int[] newBuffer = new int[_arraySize];
            Array.Copy(_buffer, newBuffer, index);
            newBuffer[index] = value;
            Array.Copy(_buffer, index, newBuffer, index + 1, _count - index);
            _buffer = newBuffer;
        }
        else
        {
            Array.Copy(_buffer, index, _buffer, index + 1, _count - index);
            _buffer[index] = value;
        }

        _count++;
        return true;
    }

    public bool TryErase(int index)
    {
        if (index < 0 || index >= _count)
        {
            return false;
        }

        Array.Copy(_buffer, index + 1, _buffer, index, _count - index - 1);
        _count--;
        return true;
    }

    public bool TryGetAt(int index, out int result)
    {
        if (index < 0 || index >= _count)
        {
            result = 0;
            return false;
        }

        result = _buffer[index];
        return true;
    }

    public void Clear()
    {
        _count = 0;
    }

    public bool TryForceArraySize(int newArraySize)
    {
        if (newArraySize < 0)
        {
            return false;
        }

        _arraySize = newArraySize;
        int[] newBuffer = new int[_arraySize];
        Array.Copy(_buffer, newBuffer, _count);
        _buffer = newBuffer;

        return true;
    }

    public int Search(int value)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_buffer[i] == value)
            {
                return i;
            }
        }
        return -1;
    }
}